using UnityEngine;
using TMPro;            // Para manipular componente de Texto do canvas
using UnityEngine.UI;   // Responsavel pelos componentes de UI

public class UIManager : MonoBehaviour
{
    // Variaveis de Scripts
    private Player player;          // Referencia do script player
    private Inventory inventory;    // Referencia do script do inventario
    // ------------------------

    // Variaveis de Componentes
    // ------------------------

    // Variaveis de Controle
    // ------------------------

    // Variaveis de Armas, Ataque, Prefab, Game Object e Audio
    // ------------------------

    // Variaveis de UI
    public TMP_Text healthText;     // Qts de Vidas Player
    // ------------------------

    void Awake()
    {
        
    }

    void Start()
    {
        // Associa Scripts
        player = GameObject.Find("Player").GetComponent<Player>();  // Associa Player em tempo de execução

        // Associa Componentes

        // Variaveis de Controle, metodos e funções

        // Associa Armas, Ataque, Prefab e Game Object
    }

    void Update()
    {
        
    }
}
