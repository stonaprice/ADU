using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitStateController : StateControllerBase
{
    private Transform tower;
    private GameObject unit;
    // UnitStateChild_MoveToTower mmt = default;

    public enum StateType
    {
        MoveToTower,
        MoveToEnemy,
        Attack,
        Move,
        Attack2,
    }
    // 初期化処理
    public override void Initialize(int initializeStateType)
    {
	    // 移動
	    stateDic[(int)StateType.Move] = gameObject.AddComponent<UnitStateChild_Move>();
	    stateDic[(int)StateType.Move].Initialize((int)StateType.Move);

	    // 同じオブジェクト内の他のスクリプトを参照する場合
	    UnitStateChild_Move move = GetComponent<UnitStateChild_Move>();
	    move.SetTower(tower);
	    move.SetUnit(unit);

	    // 攻撃
	    stateDic[(int)StateType.Attack2] = gameObject.AddComponent<UnitStateChild_Attack2>();
	    stateDic[(int)StateType.Attack2].Initialize((int)StateType.Attack2);

	    CurrentState = initializeStateType;
	    // stateDic[CurrentState].SetTower(tower);
	    // stateDic[CurrentState].SetUnit(unit);
	    stateDic[CurrentState].OnEnter();
	    
  //       // 塔へ移動
  //       stateDic[(int)StateType.MoveToTower] = gameObject.AddComponent<UnitStateChild_MoveToTower>();
  //       stateDic[(int)StateType.MoveToTower].Initialize((int)StateType.MoveToTower);
  //
  //       // 同じオブジェクト内の他のスクリプトを参照する場合
		// UnitStateChild_MoveToTower mmt = GetComponent<UnitStateChild_MoveToTower>();
  //       mmt.SetTower(tower);
  //       mmt.SetUnit(unit);
  //
  //       // 敵へ移動
  //       stateDic[(int)StateType.MoveToEnemy] = gameObject.AddComponent<UnitStateChild_MoveToEnemy>();
  //       stateDic[(int)StateType.MoveToEnemy].Initialize((int)StateType.MoveToEnemy);
  //
  //       // 攻撃
  //       stateDic[(int)StateType.Attack] = gameObject.AddComponent<UnitStateChild_Attack>();
  //       stateDic[(int)StateType.Attack].Initialize((int)StateType.Attack);
  //
  //       CurrentState = initializeStateType;
  //       // stateDic[CurrentState].SetTower(tower);
  //       // stateDic[CurrentState].SetUnit(unit);
  //       stateDic[CurrentState].OnEnter();
    }

    public void SetUnit(GameObject unit) {
		this.unit = unit;
	}

    public void SetTower(Transform tower) {
		this.tower = tower;
	}
}