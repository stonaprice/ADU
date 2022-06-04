using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitStateChild_MoveToEnemy : StateChildBase
{
    private UnityEngine.AI.NavMeshAgent navMeshAgent;
    // private Collider target;
    private GameObject target;

    float attackDistance = 5;
    private bool isAttacking = false;

    public override void OnEnter()
    {
        Debug.Log("suitou");
        navMeshAgent = GetComponentInParent<UnityEngine.AI.NavMeshAgent>();//��ԏ�̐e�ɂ��Ă���R���|�[�l���g���擾����
        // navMeshAgent = GetComponent<UnityEngine.AI.NavMeshAgent>(); // NavMeshAgent

        UnitStateChild_MoveToTower mtt = GetComponent<UnitStateChild_MoveToTower>();
        mtt.SetIsFinding(false);

        if(target){
            navMeshAgent.destination = target.transform.position;
        }
    }

    public override void OnExit()
    {
        // Do Nothing.
    }

    public override int StateUpdate()
    {
        if(target){
            CheckDistance();
        }else{
            return (int)UnitStateController.StateType.MoveToTower;
        }

        if(isAttacking){
		    UnitStateChild_Attack usca = GetComponent<UnitStateChild_Attack>();
            usca.SetTarget(target);

            return (int)UnitStateController.StateType.Attack;
        }

        return (int)UnitStateController.StateType.MoveToEnemy;
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

    public void SetTarget(GameObject target){
        this.target = target;
    }

    // public void SetTarget(Collider target){
    //     this.target = target;
    // }
}
