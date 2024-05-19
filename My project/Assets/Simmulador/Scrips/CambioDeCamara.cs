using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class CambioDeCamara : MonoBehaviour
{
    public GameObject objeto; // El objeto que quieres mover
    public GameObject objetoAdicional; // El objeto que solo se activa en la posición 3
    public GameObject tanque; // El objeto cuyo posicion se sumará a la posición definida

    // Definir las posiciones base a las que se puede mover el objeto
    public Vector3 position1;
    public Vector3 position2;
    public Vector3 position3;

    void Start()
    {
        // Inicialmente posicionar el objeto en la primera posición más la posición del tanque
        objeto.transform.position = position1 + tanque.transform.position;

        // Desactivar el objeto adicional al inicio
        objetoAdicional.SetActive(false);
    }

    void Update()
    {
        // Si se presiona el botón A, mover el objeto a la posición 1 más la posición del tanque
        if (OVRInput.GetDown(OVRInput.Button.One)) // Botón A en Oculus Quest
        {
            objeto.transform.position = position1 + tanque.transform.position;
            objetoAdicional.SetActive(false); // Desactivar el objeto adicional
        }

        // Si se presiona el botón B, mover el objeto a la posición 2 más la posición del tanque
        if (OVRInput.GetDown(OVRInput.Button.Two)) // Botón B en Oculus Quest
        {
            objeto.transform.position = position2 + tanque.transform.position;
            objetoAdicional.SetActive(false); // Desactivar el objeto adicional
        }

        // Si se presiona el botón Y, mover el objeto a la posición 3 más la posición del tanque
        if (OVRInput.GetDown(OVRInput.Button.Four) ) // Botón Y en Oculus Quest
        {
            objeto.transform.position = position3 + tanque.transform.position;
            objetoAdicional.SetActive(true); // Activar el objeto adicional
        }
    }
}