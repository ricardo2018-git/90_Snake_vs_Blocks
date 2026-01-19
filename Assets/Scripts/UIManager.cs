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
    private int points;             // Qts de pontos para calculos
    // ------------------------

    // Variaveis de Armas, Ataque, Prefab, Game Object e Audio
    // ------------------------

    // Variaveis de UI
    public TMP_Text healthText;     // Qts de Vidas player
    public TMP_Text pointsText;      // Qts de pontos feito pelo player
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
        points = 0;             // Inicia pontualçao em zero
        if(pointsText != null)  // Verifica se texto UI é null
        {
            pointsText.text = points.ToString();    // Inicia pontuação do UI em zero
        }
        
        // Associa Armas, Ataque, Prefab e Game Object
    }

    void Update()
    {
        
    }
    
    public void Score(int amount)   // Atualiza pontuação na UI
    {
        points += amount;                       // Soma pontos atuais mais pontos recebidos
        pointsText.text = points.ToString();    // Atualiza pontuação na UI
    }
}
