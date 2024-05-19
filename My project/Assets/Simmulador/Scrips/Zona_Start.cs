using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;


public class Zona_Start : MonoBehaviour
{
    // Referencia al componente TextMeshProUGUI que mostrará el mensaje
    public TextMeshProUGUI messageText;

    // Referencia al GameObject que se activará al entrar en el trigger
    public GameObject enemigos;

    // Mensaje que se mostrará en el TextMeshProUGUI
    public string message = "Trigger Activated!";

    // Método Start se llama antes del primer frame update
    void Start()
    {
    }

    // Método OnTriggerEnter se llama cuando otro collider entra en el trigger
    void OnTriggerEnter(Collider other)
    {
        // Comprobar si el objeto que entra en el trigger tiene la etiqueta "Player"
        if (other.CompareTag("Player"))
        {
            // Si la referencia a TextMeshProUGUI está asignada, actualizar el texto y activarlo
            if (messageText != null)
            {
                messageText.text = message; // Enviar el mensaje al TextMeshPro
                enemigos.SetActive(true); // Enemigos

                StartCoroutine(HideMessageAfterDelay(8));
            }
        }
    }
    IEnumerator HideMessageAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay); // Esperar el tiempo especificado
        if (messageText != null)
        {
            messageText.gameObject.SetActive(false); // Desactivar el TextMeshProUGUI
        }
    }
}