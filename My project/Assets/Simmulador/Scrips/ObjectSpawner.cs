using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ObjectSpawner : MonoBehaviour
{
    public float tiempoDeEsperaEntreActivaciones = 10f; // Tiempo de espera en segundos entre cada activación de hijo

    void Start()
    {
        // Iniciar la coroutine para activar los hijos uno por uno después de un tiempo
        StartCoroutine(ActivarHijosUnoPorUno());
    }

    IEnumerator ActivarHijosUnoPorUno()
    {
        // Recorrer cada hijo del objeto padre
        foreach (Transform hijo in transform)
        {
            // Esperar el tiempo especificado antes de activar el siguiente hijo
            yield return new WaitForSeconds(tiempoDeEsperaEntreActivaciones);

            // Activar el hijo actual
            hijo.gameObject.SetActive(true);
        }
    }
}