using JetBrains.Annotations;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    // Variaveis de Scripts
    public static Inventory inventory;  // Referencia desse script
    private UIManager uiManager;        // Referencia script uimanager
    // ------------------------

    // Variaveis de Componentes
    // ------------------------

    // Variaveis de Controle
    // ------------------------

    // Variaveis de Armas, Ataque, Prefab, Game Object e Audio
    // ------------------------

    void Awake()
    {
        // Sistema para não ser destruido esse script entre cenas
        if (inventory == null)        // Verifica se a instancia é nula
        {
            inventory = this;         // Gera instancia desse script
        }
        else if (inventory != this)   // Verifica se a instancia é diferente desse obj
        {
            Destroy(gameObject);        // Destroi obj de cena
        }
        transform.parent = null;        // Remove o parent, tornando root. Ou seja ele so pode ser persistido se não for filho, mas isso resolve o problema
        DontDestroyOnLoad(gameObject);  // Não deixa destruir esse script entre cena ou quando recarregar cena
    }

    void Start()
    {
        // Associa Scripts
        uiManager = GameObject.Find("Canvas").GetComponent<UIManager>();    // Procura obj Canvas e inicia acesso ao script
        
        // Associa Componentes

        // Variaveis de Controle, metodos e funções
        LoadInventory();    // Carrega todos itens do inventario

        // Associa Armas, Ataque, Prefab e Game Object
    }

    void Update()
    {
        
    }

    void LoadInventory()    // Carrega todos itens no inventario, isso é para quando o player para de jogar e reiniciar o jogo outro dia
    {
        
    }

    public void AddItem01(/*Item item*/)    // Mudar nome do item01 e nome do parametro tambem
    {
        
    }

    public bool CheckItemName(/*Item item*/)    // Verifica se existe item na lista do item, retorna valor boleano caso ache ou não
    {/*
        for (int i = 0; i < itens.Count; i++)    // Percorre toda lista de chaves
        {
            if (itens[i] == item)                 // Verifica na posição i se é a chave que estamos procurando
            {
                return true;                    // Retorna que achou a chave procurada
            }
        }
        */
        return false;                           // Seguinifica que não existe essa chave no lista de chaves
    }

    public void RemoveItem(/*Item item*/)       // Remove item ja usado
    {
        
    }

    public int CountItems(/*Item item*/)
    {
        int qtsItem = 0;
        // For na lista
        return qtsItem;
    }
}
