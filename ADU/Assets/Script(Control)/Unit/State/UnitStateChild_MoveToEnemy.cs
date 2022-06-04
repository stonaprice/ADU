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
        navMeshAgent = GetComponentInParent<UnityEngine.AI.NavMeshAgent>();//一番上の親についているコンポーネントを取得する
        // navMeshAgent = GetComponent<UnityEngine.AI.NavMeshAgent>(); // NavMeshAgent

        UnitStateChild_MoveToTower mtt = GetComponent<UnitStateChild_MoveToTower>();
        mtt.SetNear(false);

        navMeshAgent.destination = target.transform.position;
    }

    public override void OnExit()
    {
        // Do Nothing.
    }

    public override int StateUpdate()
    {
        // navMeshAgent.destination = target.transform.position;
        return (int)UnitStateController.StateType.MoveToEnemy;

        // if(this.gameObject.CompareTag("PlayerUnit")){
        //     navMeshAgent.destination = target.transform.position;
        //     return (int)UnitStateController.StateType.MoveToEnemy;
        // }else if(this.gameObject.CompareTag("EnemyUnit")){
        //     navMeshAgent.destination = target.transform.position;
        //     return (int)UnitStateController.StateType.MoveToEnemy;
        // }

        // return (int)UnitStateController.StateType.Attack;
    }

    public void SetTarget(Collider target){
        this.target = target;
    }
}
