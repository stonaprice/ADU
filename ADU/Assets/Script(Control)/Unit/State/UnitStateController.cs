using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitStateController : StateControllerBase
{
    // ステート
    [SerializeField] UnitStateChild_MoveToTower mtt = default;

    private Transform tower;
    private GameObject unit;

    public enum StateType
    {
        MoveToTower,
        MoveToEnemy,
        Attack,
    }
    // 初期化処理
    public override void Initialize(int initializeStateType)
    {
        // 塔へ移動
        mtt.SetTower(tower);
        mtt.SetUnit(unit);
        stateDic[(int)StateType.MoveToTower] = gameObject.AddComponent<UnitStateChild_MoveToTower>();
        stateDic[(int)StateType.MoveToTower].Initialize((int)StateType.MoveToTower);

        // // 敵へ移動
        // stateDic[(int)StateType.MoveToEnemy] = gameObject.AddComponent<UnitStateChild_MoveToEnemy>();
        // stateDic[(int)StateType.MoveToEnemy].Initialize((int)StateType.MoveToEnemy);

        // // 攻撃
        // stateDic[(int)StateType.Attack] = gameObject.AddComponent<UnitStateChild_Attack>();
        // stateDic[(int)StateType.Attack].Initialize((int)StateType.Attack);

        CurrentState = initializeStateType;
        stateDic[CurrentState].OnEnter();
    }

    // // ステートの自動遷移
    // protected override void AutoStateTransitionSequence(int nextState)
    // {
    // }

    // // 近くに敵がいる場合
    // public void OnDetectObject(Collider collider)
    // {
    //     Debug.Log("sekkin");
    // }

    public void SetUnit(GameObject unit) {
		this.unit = unit;
	}

    public void SetTower(Transform tower) {
		this.tower = tower;
	}
}