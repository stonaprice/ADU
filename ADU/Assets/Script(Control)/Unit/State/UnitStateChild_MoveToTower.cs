using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitStateChild_MoveToTower : StateChildBase
{
    // public GameObject target;
    // [SerializeField] float speed;

    public override void OnEnter()
    {
        Debug.Log("kani");
    }

    public override void OnExit()
    {
        // Do Nothing.
    }

    public override int StateUpdate()
    {
        return (int)UnitStateController.StateType.Attack;
    }
}
