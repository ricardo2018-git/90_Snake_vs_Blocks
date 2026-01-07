using UnityEngine;
using TMPro;            // Para manipular componente de Texto do canvas
using UnityEngine.UI;
using System.Collections;   // Responsavel pelos componentes de UI

public class Obstacle : MonoBehaviour
{
    // Variaveis de Scripts
    public Player player;               // Referencia do player
    // ------------------------

    // Variaveis de Componentes
    private SpriteRenderer sprite;      // Sprite do object
    private Color initialColor;         // Guarda cor gerada
    // ------------------------

    // Variaveis de Controle
    private int amount;             // Qts de dano
    private int playerLives;        // Qts vidas do player
    private float nextTime;         // Controla dano no player
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
        if(player != null && nextTime < Time.time)  // Verifica se player não é null E tempo do nosso proximo ataque for menor que o tempo de jogo
        {
            PlayerDamage();     // Aplica dano no player
        }
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
        initialColor = newColor;    // Guarda cor gerada
    }

    void PlayerDamage()     // Aplica dano no player
    {
        nextTime = Time.time + GameManager.gameManager.damageTime;  // Pega tempo do jogo + tempo de dano do player
        amount--;   // Diminui em -1 o dano do abstaculo
        SetAmountText();    // Atualiza canvas
        if(amount <= 0)     // Verifica se acabou o dano do obstaculo
        {
            gameObject.SetActive(false);    // Desativa obstaculo
            player = null;                  // Tira a referencia do player
        }
        else
        {
            StopAllCoroutines();            // Para todas coroutines
            StartCoroutine(DamageColor());  // Inicia um coroutine especifica
        }
    }

    IEnumerator DamageColor()   // Animação de dano no player por cor
    {
        float timer = 0;                // Nosso cronometro cria e inicia 
        float t = 0;                    // Controla o tempo da transição
        sprite.color = initialColor;    // Passa nossa cor para cor gerada
        while (timer < GameManager.gameManager.damageTime)  // Enquanto o timer for menor que o tempo de dano
        {
            sprite.color = Color.Lerp(initialColor, Color.white, t);    // Muda nossa cor atual para branco em x=t tempo
            timer += Time.deltaTime;                                    // 
            t += Time.deltaTime / GameManager.gameManager.damageTime;   // Faz durar o tempo do [GameManager.gameManager.damageTime]
            yield return null;                                          // A cada frame
        }
        sprite.color = initialColor;    // Volta a nossa cor para cor inicial gerada
    }

    private void OnCollisionEnter2D(Collision2D other)  // Quando entrar
    {
        Player otherPlayer = other.gameObject.GetComponent<Player>();   // Referencia ao player
        if(otherPlayer != null)     // Verifica se deu certo
        {
            player = otherPlayer;   // Passa otherPlayer para player
        }
    }

    private void OnCollisionExit2D(Collision2D other)   // Quando sair
    {
        Player otherPlayer = other.gameObject.GetComponent<Player>();   // Referencia ao player
        if(otherPlayer != null)     // Verifica se deu certo
        {
            player = null;   // Passa player para null ou seja tira vinculo do player de variavel
        }
    }
}
