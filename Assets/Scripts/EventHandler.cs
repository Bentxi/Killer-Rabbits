using UnityEngine;
using UnityEngine.UIElements;

public class EventHandler : MonoBehaviour
{
    [SerializeField]
    GameObject creditsPage;

    [SerializeField]
    GameObject mainPage;

    [SerializeField]
    Texture2D backgroundImagen;

    public VisualElement accessSquare;

    public VisualElement unJugadorButton;
    public VisualElement dosJugadoresButton;
    public VisualElement configButton;
    public VisualElement creditosButton;
    public VisualElement accessButton;
    public VisualElement salirButton;
    private bool isAccessSquareVisible = false;
    

    void Awake()
    {
        Button UnJugadorButton = GetComponent<UIDocument>().rootVisualElement.Q("UnJugadorButton") as Button;
        UnJugadorButton.clicked -= StartGame;
        UnJugadorButton.clicked += StartGame;
        Button CreditosButton = GetComponent<UIDocument>().rootVisualElement.Q("CreditosButton") as Button;
        CreditosButton.clicked -= ChangePage;
        CreditosButton.clicked += ChangePage;
        Button AccesButton = GetComponent<UIDocument>().rootVisualElement.Q("AccesButton") as Button;
        AccesButton.clicked -= AccesView;
        AccesButton.clicked += AccesView;
        Button FuenteMasButton =  GetComponent<UIDocument>().rootVisualElement.Q("FuenteMas") as Button;
        FuenteMasButton.clicked -= FuenteMas;
        FuenteMasButton.clicked += FuenteMas;
        Button FuenteMenosButton =  GetComponent<UIDocument>().rootVisualElement.Q("FuenteMenos") as Button;
        FuenteMenosButton.clicked -= FuenteMenos;
        FuenteMenosButton.clicked += FuenteMenos;
        
        Button SalirButton = GetComponent<UIDocument>().rootVisualElement.Q("SalirButton") as Button;
        SalirButton.clicked -= Salir;
        SalirButton.clicked += Salir;
        
        Toggle toggle = GetComponent<UIDocument>().rootVisualElement.Q("Contraste") as Toggle;
        toggle.RegisterValueChangedCallback(ChangeContrast);
    }

    void StartGame()
    {
        gameObject.SetActive(false);
        creditsPage.SetActive(false);
    }

    void ChangePage()
    {
        var root = GetComponent<UIDocument>().rootVisualElement;
        root.style.display = DisplayStyle.None; // Ocultar la página principal
        creditsPage.GetComponent<UIDocument>().rootVisualElement.style.display = DisplayStyle.Flex; // Mostrar la página de créditos

        var creditsRoot = creditsPage.GetComponent<UIDocument>().rootVisualElement;
        Button ReturnButton = creditsRoot.Q<Button>("ReturnButton");
        ReturnButton.clicked -= ReturnToMainPage;
        ReturnButton.clicked += ReturnToMainPage;
    }

    void AccesView()
    {
        var root = GetComponent<UIDocument>().rootVisualElement;
        accessSquare = root.Q<VisualElement>("AccessSquare");
        if (isAccessSquareVisible)
        {
            accessSquare.style.display = DisplayStyle.None;
        }
        else
        {
            accessSquare.style.display = DisplayStyle.Flex;
        }

        isAccessSquareVisible = !isAccessSquareVisible;
    }
    void FuenteMas()
    {
        var root2 = GetComponent<UIDocument>().rootVisualElement;
        unJugadorButton = root2.Q<VisualElement>("UnJugadorButton");
        dosJugadoresButton = root2.Q<VisualElement>("DosJugadoresButton");
        configButton = root2.Q<VisualElement>("ConfigButton");
        creditosButton = root2.Q<VisualElement>("CreditosButton");
        accessButton = root2.Q<VisualElement>("AccesButton");
        salirButton = root2.Q<VisualElement>("SalirButton");
        
        float fuente = unJugadorButton.resolvedStyle.fontSize;
        var tamañoFuente = fuente + 1;
        unJugadorButton.style.fontSize = tamañoFuente;
        dosJugadoresButton.style.fontSize = tamañoFuente;
        configButton.style.fontSize = tamañoFuente;
        creditosButton.style.fontSize = tamañoFuente;
        accessButton.style.fontSize = tamañoFuente;
        salirButton.style.fontSize = tamañoFuente;
    }
    void FuenteMenos()
    {
        var root3 = GetComponent<UIDocument>().rootVisualElement;
        unJugadorButton = root3.Q<VisualElement>("UnJugadorButton");
        dosJugadoresButton = root3.Q<VisualElement>("DosJugadoresButton");
        configButton = root3.Q<VisualElement>("ConfigButton");
        creditosButton = root3.Q<VisualElement>("CreditosButton");
        accessButton = root3.Q<VisualElement>("AccesButton");
        salirButton = root3.Q<VisualElement>("SalirButton");
        
        float fuente = unJugadorButton.resolvedStyle.fontSize;
        var tamañoFuente = fuente - 1;
        unJugadorButton.style.fontSize = tamañoFuente;
        dosJugadoresButton.style.fontSize = tamañoFuente;
        configButton.style.fontSize = tamañoFuente;
        creditosButton.style.fontSize = tamañoFuente;
        accessButton.style.fontSize = tamañoFuente;
        salirButton.style.fontSize = tamañoFuente;
    }

    void ReturnToMainPage()
    {
        creditsPage.GetComponent<UIDocument>().rootVisualElement.style.display = DisplayStyle.None; // Ocultar la página de créditos
        var root = GetComponent<UIDocument>().rootVisualElement;
        root.style.display = DisplayStyle.Flex; // Mostrar la página principal
    }

    void ChangeContrast(ChangeEvent<bool> evt)
    {
        if (evt.newValue)
        {
            VisualElement background = GetComponent<UIDocument>().rootVisualElement.Q("Background");
            background.style.backgroundImage = null;
            background.style.backgroundColor = Color.black;
        }
        else
        {
            VisualElement background = GetComponent<UIDocument>().rootVisualElement.Q("Background");
            background.style.backgroundImage = new StyleBackground(backgroundImagen);
        }
    }
    void Salir()
    {
        Application.Quit();
    }
}
