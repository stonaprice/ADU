using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitMove : MonoBehaviour
{
    private UnityEngine.AI.NavMeshAgent navMeshAgent;

    private void Start()
    {
        navMeshAgent = GetComponent<UnityEngine.AI.NavMeshAgent>(); // NavMeshAgentを保持しておく
    }

    // CollisionDetector.csのonTriggerStayにセットし、衝突中に実行される。
    public void OnDetectObject(Collider collider)
    {
        if(this.gameObject.CompareTag("PlayerUnit")){
            // 検知したオブジェクトに「Enemy」のタグがついていれば、そのオブジェクトを追いかける
            if (collider.CompareTag("EnemyUnit"))
            {
                navMeshAgent.destination = collider.transform.position;
            }

        }else if(this.gameObject.CompareTag("EnemyUnit")){
            // 検知したオブジェクトに「Player」のタグがついていれば、そのオブジェクトを追いかける
            if (collider.CompareTag("Player"))
            {
                navMeshAgent.destination = collider.transform.position;
            }
            if (collider.CompareTag("PlayerUnit"))
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


    //     //自分の位置、ターゲット、速度
    //     transform.position = Vector3.MoveTowards(transform.position, target.transform.position, step);
    // }
}