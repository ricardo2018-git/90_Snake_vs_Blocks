using UnityEngine;

public class Player : MonoBehaviour
{
    // Variaveis de Scripts
    private GameManager gameManager;    // Referencia script game manager
    private UIManager uiManager;        // Referencia script uimanager
    // ------------------------

    // Variaveis de Componentes
    private Transform groundCheck;      // Vai acessar posição do player
    private SpriteRenderer sprite;      // Vai acessar sprite do player
    private Rigidbody2D rb;             // Vai acessar física do player
    private Animator anim;              // Vai acessar animações do player
    // ------------------------

    // Variaveis de Controle
    public int health;                  // Vida atual
    public int maxHealth;               // Maximo de vida player

    private float speed;                // Velocidade atual   
    public float jumpForce;             // Força do pulo

    private bool isDead;                // Sinaliza se player esta morto
    private bool jump;                  // Sinaliza se player esta pulando
    private bool facingRight = true;    // Sinaliza se player esta olhando para direita
    private bool onGround;              // Sinaliza se player esta no chão
    // ------------------------

    // Variaveis de Armas, Ataque, Prefab, Game Object e Audio
    // ------------------------

    void Awake()
    {
        
    }

    void Start()
    {
        // Associa Scripts
        gameManager = GameManager.gameManager;                              // Inicia acesso ao script static
        uiManager = GameObject.Find("Canvas").GetComponent<UIManager>();    // Procura obj Canvas e inicia acesso ao script

        // Associa Componentes
        sprite = GetComponent<SpriteRenderer>();    // Acessa componente
        rb = GetComponent<Rigidbody2D>();           // Acessa componente
        anim = GetComponent<Animator>();            // Acessa componente

        // Variaveis de Controle, metodos e funções
        health = gameManager.health;                // Pega qts de vidas inicial do player
        isDead = gameManager.isDead;                // Pega status da vida inicial do player
        
        // Associa Armas, Ataque, Prefab e Game Object
    }

    
    void Update()
    {
        if (!isDead)    // Verifica se Player esta Vivo
        {
            
        }
    }

    private void FixedUpdate()
    {
        if (!isDead)    // Verifica se Player esta Vivo
        {
            
        }
    }

    void Flip()                                 // Vira corpo do player
    {
        facingRight = !facingRight;             // Seta var para o valor oposto
        Vector3 scale = transform.localScale;   // Declara uma var de transforme e seta com valor do transform do Player
        scale.x *= -1;                          // Inverte o valor de x para Positivo ou Negativo, depende do estado atual do valor
        transform.localScale = scale;           // Seta o novo valor no transform do Player
    }
}
