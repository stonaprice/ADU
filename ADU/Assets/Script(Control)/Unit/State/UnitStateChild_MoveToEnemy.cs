using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitStateChild_MoveToEnemy : StateChildBase
{
    private UnityEngine.AI.NavMeshAgent navMeshAgent;

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
            if (GetComponent<Collider>().CompareTag("EnemyUnit"))
            {
                navMeshAgent.destination = GetComponent<Collider>().transform.position;

                return (int)UnitStateController.StateType.MoveToEnemy;
            }

        }else if(this.gameObject.CompareTag("EnemyUnit")){
            if (GetComponent<Collider>().CompareTag("PlayerUnit"))
            {
                navMeshAgent.destination = GetComponent<Collider>().transform.position;

                return (int)UnitStateController.StateType.MoveToEnemy;
            }
            if (GetComponent<Collider>().CompareTag("Player"))
            {
                navMeshAgent.destination = GetComponent<Collider>().transform.position;

                return (int)UnitStateController.StateType.MoveToEnemy;
            }
        }

        return (int)UnitStateController.StateType.Attack;
    }
}
