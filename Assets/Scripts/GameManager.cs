using UnityEngine;
using System.Collections;           // Necessário para usar IEnumerator e corrotinas
using UnityEngine.UI;               // Para elementos de UI
using UnityEngine.SceneManagement;  // Para carregar telas

public class GameManager : MonoBehaviour
{
    // Scripts
    public static GameManager gameManager;  // Referencia desse script
    private Player player;                  // Referencia do script player
    private UIManager uiManager;            // Referencia do script UI
    // ------------------------

    // Componentes
    // ------------------------

    // Controle Logico
    public int health = 100;                // Vida atual
    public bool isDead = false;             // Sinaliza que player esta vivo
    public float damageTime = 0.1f;         // Tempo de dano no player

    public float gameSpeed = 2;             // Velocidade da tela

    public float multiplier = 1;            // Multiplicador para aumentar a velocidade do player
    public float cicleTime = 10;            // Tempo para chamar função para aumentar o nivel

    public bool gameOver = true;            // Sinaliza se jogo acabou, Vai iniciar como true para o player não se mover antes de clicar no btn start game

    public float obstaclesDistance = 13;    // Distancia do posicionamento dos obstaculos em relação ao player

    public int obstaclesAmount = 6;         // Maximo de força do obstaculo
    public Color easyColor, mediumColor, heardColor;    // Cores dos obstaculos

    public Vector2 xLimit;                  // Limite para ser spawnado obj

    public float playerPosX, playerPosY;                // Posição do player
    public float minCamX, maxCamX, minCamY, maxCamY;    // Posição da camera
    private string filePath;                            // Caminho onde vai ser salvo arquivo
    // ------------------------

    // Armas, Ataque, Prefab, Game Object e Audio
    public ObjectPool pickupPool;                       // Referencia pool de objetos
    public AudioClip clickSound;                        // Sons
    // ------------------------

    // UI
    public GameObject gamePanel;        // Recebe painel UI 
    public GameObject startPanel;       // Recebe painel UI Inicio de jogo
    public GameObject gameOverPanel;    // Recebe painel UI game over
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
        //DontDestroyOnLoad(gameObject);  // Não deixa destruir esse script entre cena ou quando recarregar cena
        
        //filePath = Application.persistentDataPath + "/playerInfo.dat";  // Passa o caminho e nome do arquivo que deve ser salvo os dados do Player
        //Path onde vai esta o arquivo: C:\Users\rp_mi\AppData\LocalLow\DefaultCompany\90_Snake_vs_Blocks\playerInfo.dat
        //Load();     // Carrega dados salvo Fase etc..
    }

    IEnumerator Start()
    {
        // Associa Scripts
        player = GameObject.Find("Player").GetComponent<Player>();          // Associa Player em tempo de execução
        uiManager = FindAnyObjectByType<UIManager>();   // Procura pelo Script UIManager em todos gameObject

        // Associa Componentes

        // Variaveis de Controle, metodos e funções
        while (gameOver)    // Enquando for verdadeiro
        {
            yield return null;  // Retorna um frame, precisei mudar start para corroutina
        }

        SpawnPickups();     // Inicia loop para spawn de obj
        InvokeRepeating("IncreaseDifficulty", cicleTime, cicleTime);    // Fica executando infinitamente essa função. x = a primeira chamada, y = o tempo das proximas chamadas

        // Associa Armas, Ataque, Prefab e Game Object
    }

    
    void Update()
    {
        
    }

    public void StartGame()     // Inicia jogo
    {
        AudioSource.PlayClipAtPoint(clickSound, Camera.main.transform.position);    // Toca son, na posição da camera, pode passar volume no proximo parametro que vai de 0 até 1. *Obs sem parametro toca no valor maximo = 1
        gamePanel.SetActive(true);      // Ativa painel em cena
        startPanel.SetActive(false);    // Desativa painel de cena
        gameOver = false;               // Libera player para inicio do jogo
    }

    public void GameOver()      // Fim de jogo
    {
        gameOver = true;                // Sinaliza que player morreu
        gameSpeed = 0;                  // Zera velocidade do jogo
        gameOverPanel.SetActive(true);  // Ativa painel game over
    }

    public void ReloadScene()   // Recarregar propria cena
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);   // Recarrega cena atual pelo index
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
