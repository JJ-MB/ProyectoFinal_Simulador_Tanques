using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Boton : MonoBehaviour
{
    public string nombreEscenaACargar; // El nombre de la escena a la que deseas cambiar

    // Funci�n que se llamar� para cambiar de escena
    public void CargarEscena()
    {
        // Cambia a la escena especificada
        SceneManager.LoadScene(nombreEscenaACargar);
    }

}










/*
{
public string nombreEscenaACargar; // El nombre de la escena a la que deseas cambiar

void Update()
{
    // Verifica si el bot�n del gatillo derecho del controlador Oculus Quest es presionado en este frame
    if (OVRInput.GetDown(OVRInput.Button.SecondaryIndexTrigger))
    {
        // Llama a la funci�n CargarEscena cuando el bot�n del gatillo es seleccionado
        CargarEscena();
    }
}

// Funci�n que se llamar� para cambiar de escena
void CargarEscena()
{
    // Cambia a la escena especificada
    SceneManager.LoadScene(nombreEscenaACargar);
}
}
*/