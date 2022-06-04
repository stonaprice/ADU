using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitStateChild_MoveToEnemy : StateChildBase
{
    private UnityEngine.AI.NavMeshAgent navMeshAgent;
    private Collider target;

    float attackDistance = 2;
    bool isAttacking = false;

    public override void OnEnter()
    {
        Debug.Log("suitou");
        navMeshAgent = GetComponentInParent<UnityEngine.AI.NavMeshAgent>();//��ԏ�̐e�ɂ��Ă���R���|�[�l���g���擾����
        // navMeshAgent = GetComponent<UnityEngine.AI.NavMeshAgent>(); // NavMeshAgent

        UnitStateChild_MoveToTower mtt = GetComponent<UnitStateChild_MoveToTower>();
        mtt.SetIsFinding(false);

        navMeshAgent.destination = target.transform.position;
    }

    public override void OnExit()
    {
        // Do Nothing.
    }

    public override int StateUpdate()
    {
        CheckDistance();

        if(isAttacking){
            return (int)UnitStateController.StateType.Attack;
        }

        // navMeshAgent.destination = target.transform.position;
        return (int)UnitStateController.StateType.MoveToEnemy;


        // return (int)UnitStateController.StateType.Attack;
    }

    void CheckDistance()
    {
        // �v���C���[�܂ł̋����i��悳�ꂽ�l�j���擾
        // sqrMagnitude�͕������̌v�Z���s��Ȃ��̂ō����B�������r���邾���Ȃ炻������g���������ǂ�
        float diff = (target.transform.position - this.transform.position).sqrMagnitude;
        // �������r�B��r�Ώۂ���悷��̂�Y�ꂸ��
        if (diff < attackDistance * attackDistance)
        {
            isAttacking = true;
        }
    }

    public void SetTarget(Collider target){
        this.target = target;
    }
}
