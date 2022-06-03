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
    }
    // 初期化処理
    public override void Initialize(int initializeStateType)
    {
        // 塔へ移動
        stateDic[(int)StateType.MoveToTower] = gameObject.AddComponent<UnitStateChild_MoveToTower>();
        stateDic[(int)StateType.MoveToTower].Initialize((int)StateType.MoveToTower);

        // 同じオブジェクト内の他のスクリプトを参照する場合
		UnitStateChild_MoveToTower mmt = GetComponent<UnitStateChild_MoveToTower>();
        mmt.SetTower(tower);
        mmt.SetUnit(unit);

        // 敵へ移動
        stateDic[(int)StateType.MoveToEnemy] = gameObject.AddComponent<UnitStateChild_MoveToEnemy>();
        stateDic[(int)StateType.MoveToEnemy].Initialize((int)StateType.MoveToEnemy);

        // 攻撃
        stateDic[(int)StateType.Attack] = gameObject.AddComponent<UnitStateChild_Attack>();
        stateDic[(int)StateType.Attack].Initialize((int)StateType.Attack);

        CurrentState = initializeStateType;
        // stateDic[CurrentState].SetTower(tower);
        // stateDic[CurrentState].SetUnit(unit);
        stateDic[CurrentState].OnEnter();
    }

    // 近くに敵がいる場合
    public void OnDetectObject(Collider collider)
    {
        Debug.Log("sekkin");
        // 同じオブジェクト内の他のスクリプトを参照する場合
		UnitStateChild_MoveToTower mmt = GetComponent<UnitStateChild_MoveToTower>();
        // mmt.SetNear(true);

        if(this.gameObject.CompareTag("PlayerUnit")){
            mmt.SetNear(true);
            // GameObject item = GameObject.FindWithTag("EnemyUnit");
            // Debug.Log(item.name);
            
            if (collider.CompareTag("EnemyUnit"))
            {
                mmt.SetNear(true);
            }

        }else if(this.gameObject.CompareTag("EnemyUnit")){
            if (collider.CompareTag("PlayerUnit"))
            {
                mmt.SetNear(true);
            }
            if (collider.CompareTag("Player"))
            {
                mmt.SetNear(true);
            }
        }
    }

    public void SetUnit(GameObject unit) {
		this.unit = unit;
	}

    public void SetTower(Transform tower) {
		this.tower = tower;
	}
}