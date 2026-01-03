using UnityEngine;
using TMPro;            // Para manipular componente de Texto do canvas
using UnityEngine.UI;   // Para manipular componente de UI

public class Pickup : MonoBehaviour
{
    // Variaveis de Scripts
    // ------------------------

    // Variaveis de Componentes
    // ------------------------

    // Variaveis de Controle
    private int amount;             // Qts de pickup do obj numerico
    // ------------------------

    // Variaveis de Armas, Ataque, Prefab, Game Object e Audio
    public GameObject bodyPrefab;   // Referencia do corpo do player
    // ------------------------

    // Variaveis de UI
    public TMP_Text amountText;     // Qts de pickup do obj em texto
    // ------------------------

    void Start()
    {
        // Associa Scripts

        // Associa Componentes

        // Variaveis de Controle, metodos e funções

        // Associa Armas, Ataque, Prefab e Game Object
    }

    
    void Update()
    {
        
    }

    private void OnEnable()     // É chamada quando obj é ativado em cena
    {
        amount = Random.Range(1, 6);            // Sorteia um numero entre x e y-1. Obs: Nessa caso ele vai sertear ente 1 e 5
        amountText.text = amount.ToString();    // Converte valor sorteado para string e coloca no texto do canvas
    }

    private void OnTriggerEnter2D(Collider2D other) // É chamando quando colider com outro obj
    {
        if (other.CompareTag("Player"))     // Verifica se obj contem tag player
        {
            for(int i = 0; i < amount; i++)     // Repete o processo x vezes. Nesse caso a quantidade de amount
            {
                int index = other.transform.childCount;                         // Acessa obj e conta quantidade de filhos que ele tem
                GameObject newBody = Instantiate(bodyPrefab, other.transform);  // Instancia o corpo como filho do player
                newBody.transform.localPosition = new Vector3(0, -index, 0);    // 
            }
        }
    }
}
