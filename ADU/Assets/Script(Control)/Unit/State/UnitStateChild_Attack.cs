using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitStateChild_Attack : StateChildBase
{
    // private Collider target;
    private GameObject target;
    float attackDistance = 5;
    float countTime = 0;

    FireBullet fb;
    private bool isAttacking = true;

    public override void OnEnter()
    {
        Debug.Log("Attack");

        fb = GetComponentInParent<FireBullet>();
        fb.SetIsAttacking(true);
    }

    public override void OnExit()
    {
        // Do Nothing.
    }

    public override int StateUpdate()
    {
        // �Q�[���J�n����C�������͍U�����Ă���̎���
        countTime += Time.deltaTime;

        if(target){
            CheckDistance();
        }

        if(isAttacking){
            if(1000 < countTime){
                fb.SetIsAttacking(false);
                countTime = 0;
            }
            return (int)UnitStateController.StateType.Attack;
        }

        return (int)UnitStateController.StateType.MoveToTower;
    }

    void CheckDistance()
    {
        // �v���C���[�܂ł̋����i��悳�ꂽ�l�j���擾
        // sqrMagnitude�͕������̌v�Z���s��Ȃ��̂ō����B�������r���邾���Ȃ炻������g���������ǂ�
        float diff = (target.transform.position - this.transform.position).sqrMagnitude;
        // �������r�B��r�Ώۂ���悷��̂�Y�ꂸ��
        if (attackDistance * attackDistance < diff)
        {
            isAttacking = false;
        }
    }

    public void SetTarget(GameObject target){
        this.target = target;
    }

    // public void SetTarget(Collider target){
    //     this.target = target;
    // }
}
