using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotacion_AI : MonoBehaviour
{
    // Start is called before the first frame update

    // Punto hacia el que el objeto debe apuntar
    public Transform Player;

    // Velocidad de rotación del objeto
    public float velocidadRotacion = 50f;

    public bool UserDetectTorreta;

    public void OnTriggerEnter(Collider other)
    {
        UserDetectTorreta = true;
    }

    // Update is called once per frame
    void Update()
    {
        if(UserDetectTorreta)
        {
            // Calcula la dirección hacia el jugador
            Vector3 direction = (Player.position - transform.position).normalized;

            // Calcula el ángulo hacia el jugador
            float angle = Mathf.Atan2(direction.z*(-1), direction.x) * Mathf.Rad2Deg;

            // Ajusta la rotación del ángulo para que sea local al eje -Z
            Quaternion targetRotation = Quaternion.Euler(-90f, 0f, angle + 90f);

            // Rota gradualmente hacia el jugador solo en el eje -Z
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, velocidadRotacion * Time.deltaTime);
        }
    }
}
