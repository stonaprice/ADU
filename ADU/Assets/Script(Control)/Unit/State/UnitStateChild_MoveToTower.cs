using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitStateChild_MoveToTower : StateChildBase
{
    private UnityEngine.AI.NavMeshAgent navMeshAgent;

    private Transform tower;
    private GameObject unit;
    private bool isFinding = false;
    private float findDistance = 10;

    private GameObject closeEnemy;

    private GameObject[] targets1;
    private GameObject[] targets2;
    private GameObject[] targets3;

    // �u�����l�v�̐ݒ�
    private float closeDist = 1000;

    // void Start(){
    //     // navMeshAgent = GetComponent<UnityEngine.AI.NavMeshAgent>();
    //     // navMeshAgent.destination = enemyTower.position;
    //     // navMeshAgent.destination = tower.position;
    // }

    public override void OnEnter()
    {
        Debug.Log("kani");
        // navMeshAgent = GetComponent<UnityEngine.AI.NavMeshAgent>(); // NavMeshAgent

        navMeshAgent = unit.GetComponent<UnityEngine.AI.NavMeshAgent>();
        navMeshAgent.destination = tower.position;

        // �^�O���g���ĉ�ʏ�̑S�Ă̓G�̏����擾
        if(this.gameObject.CompareTag("PlayerUnit")){
            // targets1 = GameObject.FindGameObjectsWithTag("Enemy");
            targets2 = GameObject.FindGameObjectsWithTag("EnemyUnit");
            targets3 = GameObject.FindGameObjectsWithTag("EnemyTower");
        }
        else if(this.gameObject.CompareTag("EnemyUnit")){
            targets1 = GameObject.FindGameObjectsWithTag("Player");
            targets2 = GameObject.FindGameObjectsWithTag("PlayerUnit");
            targets3 = GameObject.FindGameObjectsWithTag("PlayerTower");
        }
    }

    public override void OnExit()
    {
        // Do Nothing.
    }

    public override int StateUpdate()
    {

        if(this.gameObject.CompareTag("EnemyUnit")){
            foreach (GameObject t in targets1){
                SearchNearest(t);
            }
        }
        foreach (GameObject t in targets2){
            SearchNearest(t);
        }
        foreach (GameObject t in targets3){
            SearchNearest(t);
        }

        if(closeEnemy){
            CheckDistance();
        }

        if(isFinding){
            UnitStateChild_MoveToEnemy mte = GetComponent<UnitStateChild_MoveToEnemy>();
            mte.SetTarget(closeEnemy);

            return (int)UnitStateController.StateType.MoveToEnemy;
        }

        // navMeshAgent.destination = tower.position;

        return (int)UnitStateController.StateType.MoveToTower;
    }

    void SearchNearest(GameObject t){
        // // �R���\�[����ʂł̊m�F�p�R�[�h
        // print(Vector3.Distance(transform.position, t.transform.position));
        if(t){
            // ���̃I�u�W�F�N�g�i�C�e�j�ƓG�܂ł̋������v��
            float tDist = Vector3.Distance(transform.position, t.transform.position);

            // �������u�����l�v�����u�v�������G�܂ł̋����v�̕����߂��Ȃ�΁A
            if(closeDist > tDist)
            {
                // �ucloseDist�v���utDist�i���̓G�܂ł̋����j�v�ɒu��������B
                // ������J��Ԃ����ƂŁA��ԋ߂��G�������o�����Ƃ��ł���B
                closeDist = tDist;

                // ��ԋ߂��G�̏���closeEnemy�Ƃ����ϐ��Ɋi�[����i���j
                closeEnemy = t;
            }
        }
    }

    void CheckDistance()
    {
        // �v���C���[�܂ł̋����i��悳�ꂽ�l�j���擾
        // sqrMagnitude�͕������̌v�Z���s��Ȃ��̂ō����B�������r���邾���Ȃ炻������g���������ǂ�
        float diff = (closeEnemy.transform.position - this.transform.position).sqrMagnitude;
        // �������r�B��r�Ώۂ���悷��̂�Y�ꂸ��
        if (diff < findDistance * findDistance)
        {
            isFinding = true;
        }
    }

    public void SetUnit(GameObject unit) {
		this.unit = unit;
	}

    public void SetTower(Transform tower) {
		this.tower = tower;
	}

    public void SetIsFinding(bool isFinding){
        this.isFinding = isFinding;
    }
}