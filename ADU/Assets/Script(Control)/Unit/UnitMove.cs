using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitMove : MonoBehaviour
{
    private UnityEngine.AI.NavMeshAgent navMeshAgent;

    private void Start()
    {
        navMeshAgent = GetComponent<UnityEngine.AI.NavMeshAgent>(); // NavMeshAgent
    }

    public void OnDetectObject(Collider collider)
    {
        if(this.gameObject.CompareTag("PlayerUnit")){
            if (collider.CompareTag("EnemyUnit"))
            {
                navMeshAgent.destination = collider.transform.position;
            }
            if (collider.CompareTag("EnemyTower"))
            {
                navMeshAgent.destination = collider.transform.position;
            }

        }else if(this.gameObject.CompareTag("EnemyUnit")){
            if (collider.CompareTag("PlayerUnit"))
            {
                navMeshAgent.destination = collider.transform.position;
            }
            if (collider.CompareTag("Player"))
            {
                navMeshAgent.destination = collider.transform.position;
            }
            if (collider.CompareTag("PlayerTower"))
            {
                navMeshAgent.destination = collider.transform.position;
            }

        }
    }

    // public GameObject target;
    // [SerializeField] float speed;

    // void Update()
    // {
    //     float step = speed * Time.deltaTime;


    //     //�����̈ʒu�A�^�[�Q�b�g�A���x
    //     transform.position = Vector3.MoveTowards(transform.position, target.transform.position, step);
    // }
}