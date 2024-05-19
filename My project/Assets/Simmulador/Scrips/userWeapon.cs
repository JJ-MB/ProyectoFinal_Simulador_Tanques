using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class userWeapon : MonoBehaviour

{
    public GameObject Audios; // shot
    public Transform bulletStart;
    public GameObject bullet;
    public float bulletForce;

    private bool canShoot = true; // Variable para controlar si se puede disparar

    // Update is called once per frame
    void Update()
    {
        if ((OVRInput.GetDown(OVRInput.Button.SecondaryIndexTrigger) || Input.GetMouseButtonDown(1)) && canShoot)
        {
            StartCoroutine(Shoot());
        }
    }

    private IEnumerator Shoot()
    {
        Audios.SetActive(true);

        canShoot = false; // Evitar disparos mientras se espera

        GameObject newBullet = Instantiate(bullet, bulletStart.transform.position, bulletStart.rotation);
        Rigidbody bulletforce = newBullet.GetComponent<Rigidbody>();
        bulletforce.AddForce(bulletStart.forward * bulletForce, ForceMode.Impulse);

        yield return new WaitForSeconds(5); // Esperar 5 segundos

        Audios.SetActive(false);

        canShoot = true; // Permitir disparos de nuevo

        Destroy(newBullet, 4f);
    }
}