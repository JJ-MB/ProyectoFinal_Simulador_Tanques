using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Weapon_AI : MonoBehaviour
{
    // Para interacción del usuario
    public Transform bulletStart;
    public GameObject bullet;
    public float bulletForce;

    public GameObject Audios;
    // Nueva variable para la torreta
    public Transform torreta;

    private bool canShoot = true; // Variable para controlar si se puede disparar

    // Start is called before the first frame update
    void Start()
    {
        // Iniciar la corutina para disparar automáticamente cada 8 segundos
        StartCoroutine(AutoShoot());
    }

    // Método para disparar automáticamente cada 8 segundos
    private IEnumerator AutoShoot()
    {
        while (true) // Loop infinito para disparar continuamente
        {
            if (canShoot)
            {
                Shoot();
                canShoot = false; // Evitar disparos mientras se espera
                yield return new WaitForSeconds(8); // Esperar 8 segundos
                canShoot = true; // Permitir disparos de nuevo
            }
        }
    }

    private void Shoot()
    {
        // Activar el objeto audio
        Audios.SetActive(true);

        GameObject newBullet = Instantiate(bullet, bulletStart.position, bulletStart.rotation);
        Rigidbody bulletRigidbody = newBullet.GetComponent<Rigidbody>();

        // Obtener el vector de dirección desde la torreta hacia abajo en el eje Y
        Vector3 direction = -torreta.up;

        bulletRigidbody.AddForce(direction * bulletForce, ForceMode.Impulse);

        Destroy(newBullet, 4f);

        // Desactivar el objeto que se va a toggle después de un tiempo (por ejemplo, después de 1 segundo)
        StartCoroutine(DeactivateObjectAfterDelay(Audios, 4f));
    }

    // Método para desactivar un GameObject después de un retraso
    private IEnumerator DeactivateObjectAfterDelay(GameObject obj, float delay)
    {
        yield return new WaitForSeconds(delay);
        obj.SetActive(false);
    }
    
}