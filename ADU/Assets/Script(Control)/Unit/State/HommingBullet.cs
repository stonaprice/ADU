using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HommingBullet : MonoBehaviour
{
    public float speed;
    private GameObject[] targets;
    private bool isSwitch = false;

    private GameObject closeEnemy;

    private void Start()
    {
        // �^�O���g���ĉ�ʏ�̑S�Ă̓G�̏����擾
        targets = GameObject.FindGameObjectsWithTag("EnemyTower");

        // �u�����l�v�̐ݒ�
        float closeDist = 1000;

        foreach (GameObject t in targets)
        {
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

        // �C�e�����������0.5�b��ɁA��ԋ߂��G�Ɍ������Ĉړ����J�n����B
        Invoke("SwitchOn", 0.5f);
    }

    void Update()
    {
        if(isSwitch)
        {
            float step = speed * Time.deltaTime;

            // ���œ���ꂽcloseEnemy��ړI�n�Ƃ��Đݒ肷��B
            transform.position = Vector3.MoveTowards(transform.position, closeEnemy.transform.position, step);
        }
    }

    void SwitchOn()
    {
        isSwitch = true;
    }
}