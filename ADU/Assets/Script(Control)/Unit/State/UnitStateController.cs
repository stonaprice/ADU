using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitStateController : StateControllerBase
{

    private Transform tower;
    private GameObject unit;

    public enum StateType
    {
        MoveToTower,
        MoveToEnemy,
        Attack,
    }
    // ����������
    public override void Initialize(int initializeStateType)
    {
        // ���ֈړ�
        stateDic[(int)StateType.MoveToTower] = gameObject.AddComponent<UnitStateChild_MoveToTower>();
        stateDic[(int)StateType.MoveToTower].Initialize((int)StateType.MoveToTower);

        // �����I�u�W�F�N�g���̑��̃X�N���v�g���Q�Ƃ���ꍇ
		UnitStateChild_MoveToTower mmt = GetComponent<UnitStateChild_MoveToTower>();
        mmt.SetTower(tower);
        mmt.SetUnit(unit);

        // �G�ֈړ�
        stateDic[(int)StateType.MoveToEnemy] = gameObject.AddComponent<UnitStateChild_MoveToEnemy>();
        stateDic[(int)StateType.MoveToEnemy].Initialize((int)StateType.MoveToEnemy);

        // �U��
        stateDic[(int)StateType.Attack] = gameObject.AddComponent<UnitStateChild_Attack>();
        stateDic[(int)StateType.Attack].Initialize((int)StateType.Attack);

        CurrentState = initializeStateType;
        // stateDic[CurrentState].SetTower(tower);
        // stateDic[CurrentState].SetUnit(unit);
        stateDic[CurrentState].OnEnter();
    }

    public void SetUnit(GameObject unit) {
		this.unit = unit;
	}

    public void SetTower(Transform tower) {
		this.tower = tower;
	}
}