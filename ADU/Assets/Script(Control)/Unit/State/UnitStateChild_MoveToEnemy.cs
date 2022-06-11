using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitStateChild_MoveToEnemy : StateChildBase
{
    private UnityEngine.AI.NavMeshAgent navMeshAgent;
    // private Collider target;
    private GameObject target;

    float attackDistance = 5;
    private bool isAttacking = false;

    public override void OnEnter()
    {
        Debug.Log("suitou");
        navMeshAgent = GetComponentInParent<UnityEngine.AI.NavMeshAgent>();//一番上の親についているコンポーネントを取得する
        // navMeshAgent = GetComponent<UnityEngine.AI.NavMeshAgent>(); // NavMeshAgent

        UnitStateChild_MoveToTower mtt = GetComponent<UnitStateChild_MoveToTower>();
        mtt.SetIsFinding(false);

        if(target){
            navMeshAgent.destination = target.transform.position;
        }
    }

    public override void OnExit()
    {
        // Do Nothing.
    }

    public override int StateUpdate()
    {
        if(target){
            CheckDistance();
        }else{
            return (int)UnitStateController.StateType.MoveToTower;
        }

        if(isAttacking){
		    UnitStateChild_Attack usca = GetComponent<UnitStateChild_Attack>();
            usca.SetTarget(target);

            return (int)UnitStateController.StateType.Attack;
        }

        return (int)UnitStateController.StateType.MoveToEnemy;
    }

    void CheckDistance()
    {
        // プレイヤーまでの距離（二乗された値）を取得
        // sqrMagnitudeは平方根の計算を行わないので高速。距離を比較するだけならそちらを使った方が良い
        float diff = (target.transform.position - this.transform.position).sqrMagnitude;
        // 距離を比較。比較対象も二乗するのを忘れずに
        if (diff < attackDistance * attackDistance)
        {
            isAttacking = true;
        }
    }

    public void SetTarget(GameObject target){
        this.target = target;
    }

    // public void SetTarget(Collider target){
    //     this.target = target;
    // }
}
