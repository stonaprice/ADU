using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitStateChild_MoveToEnemy : StateChildBase
{
    private UnityEngine.AI.NavMeshAgent navMeshAgent;
    private Collider target;

    public override void OnEnter()
    {
        Debug.Log("suitou");
        navMeshAgent = GetComponent<UnityEngine.AI.NavMeshAgent>(); // NavMeshAgent
    }

    public override void OnExit()
    {
        // Do Nothing.
    }

    public override int StateUpdate()
    {
        if(this.gameObject.CompareTag("PlayerUnit")){
            navMeshAgent.destination = target.transform.position;
            return (int)UnitStateController.StateType.MoveToEnemy;


            // if (target.CompareTag("EnemyUnit"))
            // {
            //     navMeshAgent.destination = GetComponent<Collider>().transform.position;
            //     return (int)UnitStateController.StateType.MoveToEnemy;
            // }

        }else if(this.gameObject.CompareTag("EnemyUnit")){
            navMeshAgent.destination = target.transform.position;
            return (int)UnitStateController.StateType.MoveToEnemy;

            // if (target.CompareTag("PlayerUnit"))
            // {
            //     navMeshAgent.destination = GetComponent<Collider>().transform.position;
            //     return (int)UnitStateController.StateType.MoveToEnemy;
            // }
            // if (target.CompareTag("Player"))
            // {
            //     navMeshAgent.destination = GetComponent<Collider>().transform.position;
            //     return (int)UnitStateController.StateType.MoveToEnemy;
            // }
        }

        return (int)UnitStateController.StateType.Attack;
    }

    public void SetTarget(Collider target){
        this.target = target;
    }
}
