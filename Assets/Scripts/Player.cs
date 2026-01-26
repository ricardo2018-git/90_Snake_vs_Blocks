using UnityEngine;
using TMPro;            // Para manipular componente de Texto do canvas
using UnityEngine.UI;   // Responsavel pelos componentes de UI

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

    public float speed = 30;            // Velocidade atual   
    public float jumpForce;             // Força do pulo

    private bool isDead;                // Sinaliza se player esta morto
    private bool jump;                  // Sinaliza se player esta pulando
    private bool facingRight = true;    // Sinaliza se player esta olhando para direita
    private bool onGround;              // Sinaliza se player esta no chão

    private float mouseDistance;        // Distancia do mouse até player

    private float lastYPos;             // Guarda a ultima posição do player no eixo y

    private bool sliding;               // Sinaliza se esta deslizando
    private int  dir;                   // Direção que ele vai deslizar, -1=esquerda e 1=direita
    // ------------------------

    // Variaveis de Armas, Ataque, Prefab, Game Object e Audio
    // ------------------------

    // Variaveis de UI
    public TMP_Text livesText;          // Qts de Vidas Player
    // ------------------------

    void Awake()
    {
        
    }

    void Start()
    {
        // Associa Scripts
        gameManager = GameManager.gameManager;          // Inicia acesso ao script static
        uiManager = FindAnyObjectByType<UIManager>();   // Procura pelo Script UIManager em todos gameObject

        // Associa Componentes
        sprite = GetComponent<SpriteRenderer>();    // Acessa componente
        rb = GetComponent<Rigidbody2D>();           // Acessa componente
        anim = GetComponent<Animator>();            // Acessa componente

        // Variaveis de Controle, metodos e funções
        health = gameManager.health;                // Pega qts de vidas inicial do player
        isDead = gameManager.isDead;                // Pega status da vida inicial do player
        lastYPos = transform.position.y;            // Pega posição inicial no eixo y do player e guarda     
        
        // Associa Armas, Ataque, Prefab e Game Object
    }

    
    void Update()
    {
        if (!isDead && gameManager.gameOver == false)    // Verifica se Player esta Vivo
        {
            Vector3 worldPoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);   // Retorna posição do mouse sobre a tela
            float xPos = worldPoint.x;                                                  // Aqui estou pegando apena a posição do mouse em x

            mouseDistance = Mathf.Clamp(xPos - transform.position.x, -1, 1);            // Limita posição entre -1 e 1

            if(transform.position.y > lastYPos + 5)    // Verifica se posição do player em y é maior que a ultima posição mais cinco
            {
                uiManager.Score(10);                // Chama metodo para atualizar pontuação em +10 na UI
                lastYPos = transform.position.y;    // Atualiza a utima posição do player com posição atual do player no eixo y
            }
        }
    }

    private void FixedUpdate()
    {
        if (!isDead && gameManager.gameOver == false)    // Verifica se Player esta Vivo
        {
            if(!sliding)    // Verifica se jogador Não esta deslizando
                rb.linearVelocity = new Vector2(mouseDistance *  speed, gameManager.gameSpeed * gameManager.multiplier); // Faz player se movimentar em x seguindo o mouse e em y valorcrecebido do game manager e é multiplicado por multiplier para aumentar dificuldade
            else            // Se ele estiver deslizando
                rb.linearVelocity = new Vector2(dir * 2.5f, gameManager.gameSpeed * gameManager.multiplier);   // Joga o player para direita ou esquerda
        }
    }

    void Flip()                                 // Vira corpo do player
    {
        facingRight = !facingRight;             // Seta var para o valor oposto
        Vector3 scale = transform.localScale;   // Declara uma var de transforme e seta com valor do transform do Player
        scale.x *= -1;                          // Inverte o valor de x para Positivo ou Negativo, depende do estado atual do valor
        transform.localScale = scale;           // Seta o novo valor no transform do Player
    }

    public void SetText(int amount)     // Atualiza qts vidas do player
    {
        livesText.text = amount.ToString();     // Atualiza qts vidas no canvas do player
    }

    public void TakeDamage()    // Aplica dano no player
    {
        if(gameManager.gameOver)    // Verifica se game over é true
            return;                 // Não deixa executar o codigo abaixo

        int children = transform.childCount;    // Retorna qts de filhos do player, ou seja qts de vidas.
        if(children <= 1)                       // Verifica se é fim de jogo
        {
            gameManager.GameOver();     // Executa função de game over
        }
        else
        {
            Destroy(transform.GetChild(children -1).gameObject);  // Destroi ultimo rabinho da cobrinha
        }
        SetText(children -1);   // Atualiza qts de vidas player no seu canvas
    }

    public void Slide(int direction)    // Direção que player vai caso ele bata em um pareira
    {
        sliding = true;                     // Sinaliza que esta deslizando
        dir = direction;                    // Recebe direção que player sair ser jogado
        Invoke("SetSlideToFalse", 0.25f);   // Executa a função em x segundos
    }

    void SetSlideToFalse()      // Reseta variavel para false
    {
        sliding = false;    // Reseta var 
    }
}
