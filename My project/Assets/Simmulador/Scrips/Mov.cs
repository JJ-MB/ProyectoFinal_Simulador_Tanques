using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NewBehaviourScript : MonoBehaviour
{
    public Transform user;
    private NavMeshAgent enemyAgent;
    public bool UserDetect;
    private bool isStopped = false;
    private int triggerCount = 0; // Contador de cuántas veces ha sido afectado por el trigger

    void Start()
    {
        enemyAgent = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        if (UserDetect && !isStopped)
        {
            enemyAgent.destination = user.position;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        // Verificar si el objeto que entra en el trigger tiene la etiqueta "BalaPlayer"
        if (other.CompareTag("BalaPlayer"))
        {
            // Incrementar el contador del trigger
            triggerCount++;

            if (triggerCount == 1)
            {
                StartCoroutine(StopAgent());
            }
            else if (triggerCount == 2)
            {
                Destroy(gameObject);
            }
        }
    }

    private IEnumerator StopAgent()
    {
        isStopped = true;
        enemyAgent.isStopped = true;

        yield return new WaitForSeconds(2);

        enemyAgent.isStopped = false;
        isStopped = false;
    }
}