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

    public float multiplier = 1;            // Multiplicador para aumentar a velocidade do player
    public float cicleTime = 10;            // Tempo para chamar função para aumentar o nivel

    public float obstaclesDistance = 13;    // Distancia do posicionamento dos obstaculos em relação ao player

    public int obstaclesAmount = 6;         // Maximo de força do obstaculo
    public Color easyColor, mediumColor, heardColor;    // Cores dos obstaculos

    public Vector2 xLimit;                  // Limite para ser spawnado obj

    public float playerPosX, playerPosY;                // Posição do player
    public float minCamX, maxCamX, minCamY, maxCamY;    // Posição da camera
    private string filePath;                            // Caminho onde vai ser salvo arquivo
    // ------------------------

    // Variaveis de Armas, Ataque, Prefab, Game Object e Audio
    public ObjectPool pickupPool;                       // Referencia pool de objetos
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
        uiManager = FindAnyObjectByType<UIManager>();   // Procura pelo Script UIManager em todos gameObject
        
        // Associa Componentes

        // Variaveis de Controle, metodos e funções
        SpawnPickups();     // Inicia loop para spawn de obj
        InvokeRepeating("IncreaseDifficulty", cicleTime, cicleTime);    // Fica executando infinitamente essa função. x = a primeira chamada, y = o tempo das proximas chamadas

        // Associa Armas, Ataque, Prefab e Game Object
    }

    
    void Update()
    {
        
    }

    void IncreaseDifficulty()   // Aumenta a difuculdade do jogo
    {
        obstaclesAmount += 2;   // Aumenta força do obstaculos
        multiplier *= 1.1f;     // Aumenta ela mesma em 10%
    }

    void SpawnPickups()     // Spawna um obj
    {
        pickupPool.GetObject().transform.position = new Vector2(Random.Range(xLimit.x, xLimit.y), player.transform.position.y + 15);    // Acessa pool de obj e posiciona acima do player
        Invoke("SpawnPickups", Random.Range(1f, 3f));   // Executa o mesmo metodos em um tempo aleatorio enter x e y
    }

    public void Save()  // Salva todos dados do jogo
    {
        
    }

    public void Load()  // Carrega todos os dados do jogo
    {
        
    }
}
