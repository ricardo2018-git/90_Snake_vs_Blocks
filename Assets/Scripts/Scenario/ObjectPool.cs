using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    // Variaveis de Scripts
    // ------------------------

    // Variaveis de Componentes
    // ------------------------

    // Variaveis de Controle
    public int amount;              // Qts de objs que vai ser instanciado do prefab
    private int index;              // Index para controlar qual posição do vetor estamos
    // ------------------------

    // Variaveis de Armas, Ataque, Prefab, Game Object e Audio
    public GameObject prefab;       // Referencia ao obj que vai ser instanciado
    public GameObject[] prefabs;    // Vai guardar todos o prefab que for instanciados
    // ------------------------

    // Variaveis de UI
    // ------------------------

    void Awake()
    {
        // Variaveis de Controle, metodos e funções
        prefabs = new GameObject[amount];               // Inicializa o vetor com tamanho de amount
        for(int i = 0; i < amount; i++)                 // Loop amount vezes
        {
            prefabs[i] = Instantiate(prefab, new Vector2(0, 15), Quaternion.identity);  // Instancia prefab dentro do vetor na posição i desse momento
            prefabs[i].SetActive(false);    // Desativa prefab da cena
        }
    }

    void Start()
    {
        // Associa Scripts

        // Associa Componentes

        

        // Associa Armas, Ataque, Prefab e Game Object
    }

    void Update()
    {
        
    }

    public GameObject GetObject()   // Acessa um prefab do vetor e retorna ele
    {
        index++;            // Soma Mais um ao index
        if(index >= amount) // Verifica se index é maior ou igual ao amount. Ou seja verifica se esta na ultima posição
        {
            index = 0;      // Reseta index para primeira posição
        }
        prefabs[index].SetActive(true); // Ativa prefab na cena
        return prefabs[index];          // Retorna prefab ativo
    }
}
