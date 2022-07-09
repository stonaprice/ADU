using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitStateChild_Attack : StateChildBase
{
    // private Collider target;
    private GameObject target;
    float attackDistance = 5;
    float countTime = 0;
    
    // private UnitStatus unitStatus = GetComponentInParent<UnitStatus>();
    // private float attackDistance = unitStatus.AttackDistance;

    FireBullet fb;
    private bool isAttacking = true;

    public override void OnEnter()
    {
        Debug.Log("Attack");

        fb = GetComponentInParent<FireBullet>();
        fb.SetIsAttacking(true);
    }

    public override void OnExit()
    {
        fb.SetIsAttacking(false);
    }

    public override int StateUpdate()
    {
        // ゲーム開始から，もしくは攻撃してからの時間
        countTime += Time.deltaTime;

        if(target){
            CheckDistance();
        }

        // Debug.Log(countTime);

        // if(isAttacking){
        //     if(1000 < countTime){
        //         fb.SetIsAttacking(false);
        //         countTime = 0;
        //     }
        //     return (int)UnitStateController.StateType.Attack;
        // }

        return (int)UnitStateController.StateType.Attack;


        return (int)UnitStateController.StateType.MoveToTower;
    }

    void CheckDistance()
    {
        // プレイヤーまでの距離（二乗された値）を取得
        // sqrMagnitudeは平方根の計算を行わないので高速。距離を比較するだけならそちらを使った方が良い
        float diff = (target.transform.position - this.transform.position).sqrMagnitude;
        // 距離を比較。比較対象も二乗するのを忘れずに
        if (attackDistance * attackDistance < diff)
        {
            isAttacking = false;
        }
    }

    public void SetTarget(GameObject target){
        this.target = target;
    }

    // public void SetTarget(Collider target){
    //     this.target = target;
    // }
}
