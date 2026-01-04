using UnityEngine;

public class FollowTarget : MonoBehaviour
{
    // Variaveis de Scripts
    // ------------------------

    // Variaveis de Componentes
    public Transform target;        // Quem vai ser seguido, atualizado dinamicamente
    // ------------------------

    // Variaveis de Controle
    public float minSpeed = 1;      // Velocidade minima
    public float averageSpeed = 15; // Velocidade média
    public float maxSpeed = 30;     // Velocidade maxima

    private float initialHeight;    // Altura maxima
    // ------------------------

    // Variaveis de Armas, Ataque, Prefab, Game Object e Audio
    // ------------------------

    // Variaveis de UI
    // ------------------------

    void Start()
    {
        // Associa Scripts

        // Associa Componentes

        // Variaveis de Controle, metodos e funções
        initialHeight = transform.localPosition.y;      // Pega a posição no eixo y

        // Associa Armas, Ataque, Prefab e Game Object
    }

    void Update()
    {
        float distance = Mathf.Abs(target.position.x - transform.position.x);   // Pega distancia em valor absoluto ou seja valor apenas positivo
        float newSpeed;                                                         // Cria variavel para receber nova velociadade
        float percent = (distance / 2);                                         // Quanto mais perto do target velocidade perto do minimo quanto mais longe velocidade perto do maximo
        newSpeed = (averageSpeed * percent) + (minSpeed * percent);             // Calculo da nova velocidade
        if(distance > 2)    // Verifica se a distancia é maior que 2
        {
            newSpeed = maxSpeed;    // Passa nova velocidade para maxima
        }
        Vector2 newPos = new Vector2(target.position.x, transform.position.y + percent);                    // Calcula nova posição
        transform.position = Vector2.MoveTowards(transform.position, newPos, newSpeed * Time.deltaTime);    // Atualiza posição ou faz seguir

        // Limita
        transform.localPosition = new Vector2(transform.localPosition.x,
            Mathf.Clamp(transform.localPosition.y, initialHeight, initialHeight + percent));    // Limita
    }
}
