using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitStateController : StateControllerBase
{
    public enum StateType
    {
        MoveToTower,
        MoveToEnemy,
        Attack,
    }
    // ‰Šú‰»ˆ—
    public override void Initialize(int initializeStateType)
    {
        // “ƒ‚ÖˆÚ“®
        stateDic[(int)StateType.MoveToTower] = gameObject.AddComponent<UnitStateChild_MoveToTower>();
        stateDic[(int)StateType.MoveToTower].Initialize((int)StateType.MoveToTower);

        // // “G‚ÖˆÚ“®
        // stateDic[(int)StateType.MoveToEnemy] = gameObject.AddComponent<UnitStateChild_MoveToEnemy>();
        // stateDic[(int)StateType.MoveToEnemy].Initialize((int)StateType.MoveToEnemy);

        // // UŒ‚
        // stateDic[(int)StateType.Attack] = gameObject.AddComponent<UnitStateChild_Attack>();
        // stateDic[(int)StateType.Attack].Initialize((int)StateType.Attack);

        CurrentState = initializeStateType;
        stateDic[CurrentState].OnEnter();
    }

    // // ƒXƒe[ƒg‚Ì©“®‘JˆÚ
    // protected override void AutoStateTransitionSequence(int nextState)
    // {
    // }

    // ‹ß‚­‚É“G‚ª‚¢‚éê‡
    public void OnDetectObject(Collider collider)
    {
        Debug.Log("sekkin");
    }
}