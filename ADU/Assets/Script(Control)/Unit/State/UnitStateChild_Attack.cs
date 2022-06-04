using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitStateChild_Attack : StateChildBase
{

    public override void OnEnter()
    {
        Debug.Log("Attack");

        FireBullet fb = GetComponentInParent<FireBullet>();
        fb.SetIsAttacking(true);
    }

    public override void OnExit()
    {
        // Do Nothing.
    }

    public override int StateUpdate()
    {
        return (int)UnitStateController.StateType.MoveToTower;
    }
}
