using UnityEngine;

public class PushPlayer : MonoBehaviour
{
    
    void Start()
    {
        
    }

    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Player player = other.GetComponent<Player>();   // Cria uma referencia para player
        if(player != null)                              // Verifica se realmente é o player
        {
            float direction = other.transform.position.x - transform.position.x;    // Identifica se player esta na esquerda ou direita. valor NEGATIVO ESQUERDA, Valor POSITIVO DIREITA
            player.Slide((int)Mathf.Sign(direction));   // Mathf.Sign retorna: 1 para valor positivo, -1 para valor negativo e 0 para 0. (int) Converte valor para inteiro
        }
    }
}
