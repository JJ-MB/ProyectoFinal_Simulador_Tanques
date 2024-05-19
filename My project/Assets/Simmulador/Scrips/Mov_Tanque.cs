using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mov_Tanque : MonoBehaviour
{
    public float velocidadMovimiento = 5.0f;
    public float velocidadRotacion = 300.0f;

    public GameObject Audios; // Mov

    private CharacterController characterController;

    void Start()
    {
        characterController = GetComponent<CharacterController>();
        if (characterController == null)
        {
            characterController = gameObject.AddComponent<CharacterController>();
        }
    }

    void Update()
    {
        // Obtener la posici�n de ambos joysticks
        Vector2 joystickDerecho = OVRInput.Get(OVRInput.Axis2D.SecondaryThumbstick);
        Vector2 joystickIzquierdo = OVRInput.Get(OVRInput.Axis2D.PrimaryThumbstick);

        Vector3 moveDirection = Vector3.zero;

        // Mover hacia adelante si ambos joysticks est�n hacia adelante
        if (joystickDerecho.y > 0.5f && joystickIzquierdo.y > 0.5f || Input.GetKey(KeyCode.W))
        {
            moveDirection = transform.forward * velocidadMovimiento;
            Audios.SetActive(true);
        }
        // Mover hacia atr�s si ambos joysticks est�n hacia atr�s
        else if (joystickDerecho.y < -0.5f && joystickIzquierdo.y < -0.5f || Input.GetKey(KeyCode.S))
        {
            moveDirection = -transform.forward * velocidadMovimiento;
            Audios.SetActive(true);
        }
        // Girar a la izquierda si el joystick derecho est� hacia adelante y el izquierdo hacia atr�s
        else if (joystickDerecho.y > 0.5f && joystickIzquierdo.y < -0.5f || Input.GetKey(KeyCode.A))
        {
            transform.Rotate(Vector3.up, -velocidadRotacion * Time.deltaTime);
            Audios.SetActive(true);
        }
        // Girar a la derecha si el joystick izquierdo est� hacia adelante y el derecho hacia atr�s
        else if (joystickIzquierdo.y > 0.5f && joystickDerecho.y < -0.5f || Input.GetKey(KeyCode.D))
        {
            transform.Rotate(Vector3.up, velocidadRotacion * Time.deltaTime);
            Audios.SetActive(true);
        }
        else
        {
            Audios.SetActive(false);
        }

        // Mover el tanque utilizando el CharacterController
        if (moveDirection != Vector3.zero)
        {
            characterController.Move(moveDirection * Time.deltaTime);
        }
    }
}