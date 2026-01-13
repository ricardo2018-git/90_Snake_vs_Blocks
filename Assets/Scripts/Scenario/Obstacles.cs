using UnityEngine;

public class Obstacles : MonoBehaviour
{
    // Variaveis de Scripts
    // ------------------------

    // Variaveis de Componentes
    private Transform player;           // Referencia da posição do player
    // ------------------------

    // Variaveis de Controle
    // ------------------------

    // Variaveis de Armas, Ataque, Prefab, Game Object e Audio
    public Obstacle[] allObstacles;     // Todos obstaculos
    public GameObject[] barriers;       // Todas barreiras
    public Vector2 positionRange;       // Posição aleatório
    public GameObject obstaclesGroup;   // Referencia do grupo de obstaculos
    // ------------------------

    // Variaveis de UI
    // ------------------------

    void Start()
    {
        // Associa Scripts

        // Associa Componentes
        player = GameObject.Find("Player").transform;   // Acessa transform do player  

        // Variaveis de Controle, metodos e funções
        SetObstacles();     // Habilita obstaculos

        // Associa Armas, Ataque, Prefab e Game Object
    }

    void Update()
    {
        
    }

    void SetObstacles()     // Habilita obstaculos
    {
        for(int i = 0; i < allObstacles.Length; i++)    // Percorre todos obstaculos
        {
            allObstacles[i].SetAmount();                // Acessa metodo do gameobject
        }

        for (int i = 0; i < barriers.Length; i++)       // Percorre todas barreiras
        {
            bool randomBool = Random.value > 0.5f;      // Retorna um valor entre 0 e 1, Se for maior que 0.5 é verdadeiro, menor é falsa
            barriers[i].SetActive(randomBool);          // Ativa ou não a barreira atual
        }
    }

    void Reposition()   // Reposiciona obstaculos
    {
        int obstaclesAmount = FindObjectsByType<Obstacles>(FindObjectsInactive.Exclude, FindObjectsSortMode.None).Length;               // Conta obj ativos
        transform.position = new Vector2(0, player.position.y + (GameManager.gameManager.obstaclesDistance * (obstaclesAmount -1)));    // Posiciona objetos acima do player em y
        obstaclesGroup.transform.localPosition = new Vector2(0, Random.Range(positionRange.x, positionRange.y));                        // Posiciona grupo de obj aleatorio
    }

    void DecreaseDifficulty()   // Deixa o jogo mai facil
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player")) // Verifica se colisão foi com player
        {
            Reposition();       // Reposiciona obstaculos
            SetObstacles();     // Habilita obstaculos
        }
    }
}
