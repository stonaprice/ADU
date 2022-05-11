using UnityEngine;
using UnityEngine.AI;


public class MoveEnemy : MonoBehaviour
{
    private NavMeshAgent navMeshAgent;

    private void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
    }


    public void OnDetectObject(Collider collider)
    {
        if (collider.CompareTag("Player"))
        {
            navMeshAgent.destination = collider.transform.position;
        }
    }
}
