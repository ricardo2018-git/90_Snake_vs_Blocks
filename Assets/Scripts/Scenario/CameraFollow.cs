using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    // Variaveis de Scripts
    // ------------------------

    // Variaveis de Componentes
    public Transform player;        // Vai acessar posição do player
    // ------------------------

    // Variaveis de Controle
    private Vector3 offset;         // Distancia da camera em relação ao player
    // ------------------------

    // Variaveis de Armas, Ataque, Prefab, Game Object e Audio
    // ------------------------

    void Start()
    {
        // Associa Scripts

        // Associa Componentes

        // Variaveis de Controle, metodos e funções
        offset = transform.position - player.transform.position;    // Recebe a distancia entre camera e player

        // Associa Armas, Ataque, Prefab e Game Object
    }

    void Update()
    {
        
    }

    private void LateUpdate()   // É chamado quando termina de redenrizar um frame
    {
        transform.position = new Vector3(0, player.position.y + offset.y, player.position.z + offset.z);    // Faz camera seguir player no eixo y
    }
}
