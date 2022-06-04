using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBullet : MonoBehaviour
{
    [SerializeField]
    [Tooltip("�e�̔��ˏꏊ")]
    private GameObject firingPoint;

    [SerializeField]
    [Tooltip("�e")]
    private GameObject bullet;

    [SerializeField]
    [Tooltip("�e�̑���")]
    private float speed = 10f;

    private GameObject newBall;
    private bool isAttacking = false;

    // private GameObject[] targets;
    // private GameObject[] targets1;
    // private GameObject[] targets2;
    // private GameObject[] targets3;

    // private bool isSwitch = false;
    // private GameObject closeEnemy;

    // Update is called once per frame
    void Update()
    {
        // �X�y�[�X�L�[�������ꂽ���𔻒�
        if (Input.GetKeyDown(KeyCode.Space))
        {
            // �e�𔭎˂���
            LauncherShot();
        }

        if(isAttacking){
            // �e�𔭎˂���
            LauncherShot();

            isAttacking = false;
        }

        // if(isSwitch)
        // {
        //     float step = speed * Time.deltaTime;

        //     // ���œ���ꂽcloseEnemy��ړI�n�Ƃ��Đݒ肷��B
        //     newBall.transform.position = Vector3.MoveTowards(newBall.transform.position, closeEnemy.transform.position, step);
        // }
    }

    /// <summary>
	/// �e�̔���
	/// </summary>
    private void LauncherShot()
    {
        // �e�𔭎˂���ꏊ���擾
        Vector3 bulletPosition = firingPoint.transform.position;
        // ��Ŏ擾�����ꏊ�ɁA"bullet"��Prefab���o��������
        newBall = Instantiate(bullet, bulletPosition, transform.rotation);
        // // �o���������{�[����forward(z������)
        // Vector3 direction = newBall.transform.forward;
        // // �e�̔��˕�����newBall��z����(���[�J�����W)�����A�e�I�u�W�F�N�g��rigidbody�ɏՌ��͂�������
        // newBall.GetComponent<Rigidbody>().AddForce(direction * speed, ForceMode.Impulse);
        // �o���������{�[���̖��O��"bullet"�ɕύX
        newBall.name = bullet.name;
        // �o���������{�[����0.8�b��ɏ���
        Destroy(newBall, 2.0f);
        // Invoke("SwitchOff", 2.0f);


        // // �u�����l�v�̐ݒ�
        // float closeDist = 1000;

        // // �^�O���g���ĉ�ʏ�̑S�Ă̓G�̏����擾
        // if(this.gameObject.CompareTag("PlayerUnit")){
        //     // targets1 = GameObject.FindGameObjectsWithTag("Enemy");
        //     // targets2 = GameObject.FindGameObjectsWithTag("EnemyUnit");
        //     // targets3 = GameObject.FindGameObjectsWithTag("EnemyTower");

        //     // targets = GameObject.FindGameObjectsWithTag("Enemy");
        //     targets = GameObject.FindGameObjectsWithTag("EnemyUnit");
        //     targets = GameObject.FindGameObjectsWithTag("EnemyTower");

        // }else if(this.gameObject.CompareTag("EnemyUnit")){
        //     // targets1 = GameObject.FindGameObjectsWithTag("Player");
        //     // targets2 = GameObject.FindGameObjectsWithTag("PlayerUnit");
        //     // targets3 = GameObject.FindGameObjectsWithTag("PlayerTower");

        //     targets = GameObject.FindGameObjectsWithTag("Player");
        //     targets = GameObject.FindGameObjectsWithTag("PlayerUnit");
        //     targets = GameObject.FindGameObjectsWithTag("PlayerTower");
        // }

        // foreach (GameObject t in targets)
        // {
        //     // �R���\�[����ʂł̊m�F�p�R�[�h
        //     print(Vector3.Distance(newBall.transform.position, t.transform.position));

        //     // ���̃I�u�W�F�N�g�i�C�e�j�ƓG�܂ł̋������v��
        //     float tDist = Vector3.Distance(newBall.transform.position, t.transform.position);

        //     // �������u�����l�v�����u�v�������G�܂ł̋����v�̕����߂��Ȃ�΁A
        //     if(closeDist > tDist)
        //     {
        //         // �ucloseDist�v���utDist�i���̓G�܂ł̋����j�v�ɒu��������B
        //         // ������J��Ԃ����ƂŁA��ԋ߂��G�������o�����Ƃ��ł���B
        //         closeDist = tDist;

        //         // ��ԋ߂��G�̏���closeEnemy�Ƃ����ϐ��Ɋi�[����i���j
        //         closeEnemy = t;
        //     }
        // }

        // SwitchOn();
        // // // �C�e�����������0.5�b��ɁA��ԋ߂��G�Ɍ������Ĉړ����J�n����B
        // // Invoke("SwitchOn", 0.5f);
    }

    // void SwitchOn()
    // {
    //     isSwitch = true;
    // }

    // void SwitchOff(){
    //     isSwitch = false;
    // }

    public void SetIsAttacking(bool isAttacking){
        this.isAttacking = isAttacking;
    }
}
