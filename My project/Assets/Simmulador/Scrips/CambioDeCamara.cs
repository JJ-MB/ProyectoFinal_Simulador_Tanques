using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class CambioDeCamara : MonoBehaviour
{
    public GameObject objeto; // El objeto que quieres mover
    public GameObject objetoAdicional; // El objeto que solo se activa en la posici�n 3
    public GameObject tanque; // El objeto cuyo posicion se sumar� a la posici�n definida

    // Definir las posiciones base a las que se puede mover el objeto
    public Vector3 position1;
    public Vector3 position2;
    public Vector3 position3;

    void Start()
    {
        // Inicialmente posicionar el objeto en la primera posici�n m�s la posici�n del tanque
        objeto.transform.position = position1 + tanque.transform.position;

        // Desactivar el objeto adicional al inicio
        objetoAdicional.SetActive(false);
    }

    void Update()
    {
        // Si se presiona el bot�n A, mover el objeto a la posici�n 1 m�s la posici�n del tanque
        if (OVRInput.GetDown(OVRInput.Button.One)) // Bot�n A en Oculus Quest
        {
            objeto.transform.position = position1 + tanque.transform.position;
            objetoAdicional.SetActive(false); // Desactivar el objeto adicional
        }

        // Si se presiona el bot�n B, mover el objeto a la posici�n 2 m�s la posici�n del tanque
        if (OVRInput.GetDown(OVRInput.Button.Two)) // Bot�n B en Oculus Quest
        {
            objeto.transform.position = position2 + tanque.transform.position;
            objetoAdicional.SetActive(false); // Desactivar el objeto adicional
        }

        // Si se presiona el bot�n Y, mover el objeto a la posici�n 3 m�s la posici�n del tanque
        if (OVRInput.GetDown(OVRInput.Button.Four) ) // Bot�n Y en Oculus Quest
        {
            objeto.transform.position = position3 + tanque.transform.position;
            objetoAdicional.SetActive(true); // Activar el objeto adicional
        }
    }
}