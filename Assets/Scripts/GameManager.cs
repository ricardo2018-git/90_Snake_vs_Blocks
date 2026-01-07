using UnityEngine;

public class GameManager : MonoBehaviour
{
    // Variaveis de Scripts
    public static GameManager gameManager;  // Referencia desse script
    private Player player;                  // Referencia do script player
    private UIManager uiManager;            // Referencia do script UI
    // ------------------------

    // Variaveis de Componentes
    // ------------------------

    // Variaveis de Controle
    public int health = 100;                // Vida atual
    public bool isDead = false;             // Sinaliza que player esta vivo
    public float damageTime = 0.1f;         // Tempo de dano no player


    public float gameSpeed = 2;             // Velocidade da tela

    public int obstaclesAmount = 6;       // Maximo de força do obstaculo
    public Color easyColor, mediumColor, heardColor;    // Cores dos obstaculos

    public float playerPosX, playerPosY;                // Posição do player
    public float minCamX, maxCamX, minCamY, maxCamY;    // Posição da camera
    private string filePath;                            // Caminho onde vai ser salvo arquivo
    // ------------------------

    // Variaveis de Armas, Ataque, Prefab, Game Object e Audio
    // ------------------------

    void Awake()
    {
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
        
        //filePath = Application.persistentDataPath + "/playerInfo.dat";  // Passa o caminho e nome do arquivo que deve ser salvo os dados do Player
        //Path onde vai esta o arquivo: C:\Users\rp_mi\AppData\LocalLow\DefaultCompany\90_Snake_vs_Blocks\playerInfo.dat
        //Load();     // Carrega dados salvo Fase etc..
    }

    void Start()
    {
        // Associa Scripts
        player = GameObject.Find("Player").GetComponent<Player>();          // Associa Player em tempo de execução
        uiManager = GameObject.Find("Canvas").GetComponent<UIManager>();    // Procura obj Canvas e inicia acesso ao script
        
        // Associa Componentes

        // Variaveis de Controle, metodos e funções

        // Associa Armas, Ataque, Prefab e Game Object
    }

    
    void Update()
    {
        
    }

    public void Save()  // Salva todos dados do jogo
    {
        
    }

    public void Load()  // Carrega todos os dados do jogo
    {
        
    }
}
