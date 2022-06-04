using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HommingBullet : MonoBehaviour
{
    public float speed;
    // private GameObject[] targets;
    private bool isSwitch = false;

    private GameObject closeEnemy;

    private GameObject[] targets1;
    private GameObject[] targets2;
    private GameObject[] targets3;

    // �u�����l�v�̐ݒ�
    private float closeDist = 1000;

    private void Start()
    {
        // �^�O���g���ĉ�ʏ�̑S�Ă̓G�̏����擾
        if(this.gameObject.CompareTag("PlayerWeapon")){
            // targets1 = GameObject.FindGameObjectsWithTag("Enemy");
            targets2 = GameObject.FindGameObjectsWithTag("EnemyUnit");
            targets3 = GameObject.FindGameObjectsWithTag("EnemyTower");
        }
        else if(this.gameObject.CompareTag("EnemyWeapon")){
            targets1 = GameObject.FindGameObjectsWithTag("Player");
            targets2 = GameObject.FindGameObjectsWithTag("PlayerUnit");
            targets3 = GameObject.FindGameObjectsWithTag("PlayerTower");
        }

        // targets = GameObject.FindGameObjectsWithTag("EnemyTower");

        // // �u�����l�v�̐ݒ�
        // float closeDist = 1000;

        if(this.gameObject.CompareTag("EnemyWeapon")){
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

        SwitchOn();
        // // �C�e�����������0.5�b��ɁA��ԋ߂��G�Ɍ������Ĉړ����J�n����B
        // Invoke("SwitchOn", 0.5f);
    }

    void Update()
    {
        if(isSwitch){
            // closeEnemy���Ȃ��ꍇStart�ɖ߂�
            if(!closeEnemy){
                Start();
            }else{
                float step = speed * Time.deltaTime;

                // ���œ���ꂽcloseEnemy��ړI�n�Ƃ��Đݒ肷��B
                transform.position = Vector3.MoveTowards(transform.position, closeEnemy.transform.position, step);
            }
        }
    }

    void SearchNearest(GameObject t){

        if(t){
            // �R���\�[����ʂł̊m�F�p�R�[�h
            print(Vector3.Distance(transform.position, t.transform.position));
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

    void SwitchOn()
    {
        isSwitch = true;
    }
}