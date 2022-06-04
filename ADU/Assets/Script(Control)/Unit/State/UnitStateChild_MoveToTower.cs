using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitStateChild_MoveToTower : StateChildBase
{
    private UnityEngine.AI.NavMeshAgent navMeshAgent;

    private Transform tower;
    private GameObject unit;
    private bool near = false;

    // void Start(){
    //     // navMeshAgent = GetComponent<UnityEngine.AI.NavMeshAgent>();
    //     // navMeshAgent.destination = enemyTower.position;
    //     // navMeshAgent.destination = tower.position;
    // }

    public override void OnEnter()
    {
        Debug.Log("kani");
        // navMeshAgent = GetComponent<UnityEngine.AI.NavMeshAgent>(); // NavMeshAgent

        navMeshAgent = unit.GetComponent<UnityEngine.AI.NavMeshAgent>();
        navMeshAgent.destination = tower.position;
    }

    public override void OnExit()
    {
        // Do Nothing.
    }

    public override int StateUpdate()
    {
        if(near == true){
            return (int)UnitStateController.StateType.MoveToEnemy;
        }

        // navMeshAgent.destination = tower.position;

        return (int)UnitStateController.StateType.MoveToTower;


    }

//     void CheckDistance()
//     {
//         // プレイヤーまでの距離（二乗された値）を取得
//         // sqrMagnitudeは平方根の計算を行わないので高速。距離を比較するだけならそちらを使った方が良い
//         float diff = (player.position - thisTransform.position).sqrMagnitude;
//         // 距離を比較。比較対象も二乗するのを忘れずに
//         if (diff < attackDistance * attackDistance)
//         {
//             if(!isAttacking)
//             {
//             StartCoroutine(nameof(Attack));
//             }
//         }
//         else if (diff < chaseDistance * chaseDistance)
//         {
//             target = player;
//         }
//         else
//         {
//             target = defaultTarget;
//         }
//   }

    public void SetUnit(GameObject unit) {
		this.unit = unit;
	}

    public void SetTower(Transform tower) {
		this.tower = tower;
	}

    public void SetNear(bool near){
        this.near = near;
    }
}