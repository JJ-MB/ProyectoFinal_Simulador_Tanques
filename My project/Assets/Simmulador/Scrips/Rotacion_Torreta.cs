using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimientoConTeclado : MonoBehaviour
{
    // Velocidad de movimiento del objeto
    public float velocidadRotacion = 5f;

    public GameObject Audios;//Torret

    void Update()
    {
        // Movimiento hacia la izquierda con la tecla A
        if (OVRInput.Get(OVRInput.Axis1D.SecondaryHandTrigger) > 0.8f || Input.GetKey(KeyCode.J))
        {
            transform.Rotate(Vector3.forward * velocidadRotacion * Time.deltaTime);
            Audios.SetActive(true);
        }

        // Movimiento hacia la derecha con la tecla D
        else if (OVRInput.Get(OVRInput.Axis1D.PrimaryHandTrigger) > 0.8f || Input.GetKey(KeyCode.L))
        {
            transform.Rotate(Vector3.back * velocidadRotacion * Time.deltaTime);
            Audios.SetActive(true);
        }
        else {
            Audios.SetActive(false);
        }
    }
}