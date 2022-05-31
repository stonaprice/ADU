using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitStateController : StateControllerBase
{
    // �X�e�[�g
    [SerializeField] UnitStateChild_MoveToTower mtt = default;

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
        mtt.SetTower(tower);
        mtt.SetUnit(unit);
        stateDic[(int)StateType.MoveToTower] = gameObject.AddComponent<UnitStateChild_MoveToTower>();
        stateDic[(int)StateType.MoveToTower].Initialize((int)StateType.MoveToTower);

        // // �G�ֈړ�
        // stateDic[(int)StateType.MoveToEnemy] = gameObject.AddComponent<UnitStateChild_MoveToEnemy>();
        // stateDic[(int)StateType.MoveToEnemy].Initialize((int)StateType.MoveToEnemy);

        // // �U��
        // stateDic[(int)StateType.Attack] = gameObject.AddComponent<UnitStateChild_Attack>();
        // stateDic[(int)StateType.Attack].Initialize((int)StateType.Attack);

        CurrentState = initializeStateType;
        stateDic[CurrentState].OnEnter();
    }

    // // �X�e�[�g�̎����J��
    // protected override void AutoStateTransitionSequence(int nextState)
    // {
    // }

    // // �߂��ɓG������ꍇ
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