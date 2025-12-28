using UnityEngine;

public class GameManager : MonoBehaviour
{
    // Variaveis de Scripts
    public static GameManager gameManager;  // Referencia desse script
    private UIManager uimanager;            // Referencia do script UI
    // ------------------------

    // Variaveis de Componentes
    // ------------------------

    // Variaveis de Controle
    // ------------------------

    // Variaveis de Armas, Ataque, Prefab, Game Object e Audio
    // ------------------------

    void Awake()
    {/*
        // Sistema para não ser destruido esse script entre cenas
        if (gameManager == null)        // Verifica se a instancia é nula
        {
            gameManager = this;         // Gera instancia desse script
        }
        else if (gameManager != this)   // Verifica se a instancia é diferente desse obj
        {
            Destroy(gameObject);        // Destroi obj de cena
        }
        DontDestroyOnLoad(gameObject);  // Não deixa destruir esse script entre cena ou quando recarregar cena
    */
    }

    void Start()
    {
        // Associa Scripts

        // Associa Componentes

        // Variaveis de Controle, metodos e funções

        // Associa Armas, Ataque, Prefab e Game Object
    }

    
    void Update()
    {
        
    }
}
