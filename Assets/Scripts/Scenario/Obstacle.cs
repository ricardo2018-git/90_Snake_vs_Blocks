using UnityEngine;
using TMPro;            // Para manipular componente de Texto do canvas
using UnityEngine.UI;   // Responsavel pelos componentes de UI

public class Obstacle : MonoBehaviour
{
    // Variaveis de Scripts
    public Player player;               // Referencia do player
    // ------------------------

    // Variaveis de Componentes
    private SpriteRenderer sprite;      // Sprite do object
    // ------------------------

    // Variaveis de Controle
    private int amount;             // Qts de dano
    private int playerLives;        // Qts vidas do player
    // ------------------------

    // Variaveis de Armas, Ataque, Prefab, Game Object e Audio
    // ------------------------

    // Variaveis de UI
    public TMP_Text amountText;     // Qts de dano 

    void Start()
    {
        // Associa Scripts
        playerLives = player.transform.childCount;  // Retorna qts de filhos do player, ou seja qts de vidas.

        // Associa Componentes
        sprite = GetComponent<SpriteRenderer>();    // Acessa proprio componente

        // Variaveis de Controle, metodos e funções

        // Associa Armas, Ataque, Prefab e Game Object
        SetAmount();    // EXCLUIR DEPOIS
    }

    void Update()
    {
        
    }

    public void SetAmount()
    {
        gameObject.SetActive(true);     // Habilita gameObject
        amount = Random.Range(0, GameManager.gameManager.obstaclesAmount);     // Sorteia um numero
        if(amount <= 0)     // Verifica se valor sorteado é menor ou igual a zero
        {
            gameObject.SetActive(false);    // Desabilita gameObject
        }
        SetAmountText();    // Atualiza canvas do gameObject
        SetColor();         // Atualiza cor do sprite do gameObject
    }

    public void SetAmountText()     // Atualiza canvas
    {
        amountText.text = amount.ToString();    // Converte para string e passa value para canvas
    }

    public void SetColor()          // Define a cor do obstaculo
    {
        Color newColor;             // Varivel para cor
        if(amount > playerLives)    // Verifica se dano é maior que qts de vida do player
        {
            newColor = GameManager.gameManager.heardColor;  // Recebe cor adm
        }
        else if(amount > playerLives / 2)   // Verifica se o dano é maior que a metade da vida do player
        {
            newColor = GameManager.gameManager.mediumColor; // Recebe cor adm
        }
        else
        {
            newColor = GameManager.gameManager.easyColor;   // Recebe cor adm
        }
        sprite.color = newColor;    // Atualiza cor do sprite do gameObject
    }
}
