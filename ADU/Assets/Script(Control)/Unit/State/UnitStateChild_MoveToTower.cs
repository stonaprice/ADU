using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitStateChild_MoveToTower : StateChildBase
{
    // public GameObject target;
    // [SerializeField] float speed;

    private UnityEngine.AI.NavMeshAgent navMeshAgent;

    // public Transform enemyTower;
    // public Transform playerTower;

    private Transform tower;
    private GameObject unit;
    private bool near = false;

    // private GameObject nearObj;         //�ł��߂��I�u�W�F�N�g

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
    }

    public override void OnExit()
    {
        // Do Nothing.
    }

    public override int StateUpdate()
    {
        // //�ł��߂������I�u�W�F�N�g���擾
        // nearObj = serchTag(gameObject, "EnemyUnit");

        // Vector3 posA = this.transform.position;
        // Vector3 posB = nearObj.transform.position;
        // float dis = Vector3.Distance(posA,posB);

        // Debug.Log(dis);

        // if(dis < 10){
        //     return (int)UnitStateController.StateType.MoveToEnemy;
        // }
        Debug.Log(near);

        // if(gameObject.CompareTag("PlayerUnit") & GetComponent<Collider>().CompareTag("EnemyUnit")){
        // // if(GetComponent<Collider>().CompareTag("EnemyUnit")){
        //     return (int)UnitStateController.StateType.MoveToEnemy;
        // }else if(this.gameObject.CompareTag("EnemyUnit") & GetComponent<Collider>().CompareTag("PlayerUnit")){
        //     return (int)UnitStateController.StateType.MoveToEnemy;
        // }

        if(near == true){
            return (int)UnitStateController.StateType.MoveToEnemy;
        }



        return (int)UnitStateController.StateType.MoveToTower;

        // if(this.gameObject.CompareTag("PlayerUnit")){
        // }else if(this.gameObject.CompareTag("EnemyUnit")){
    }

    //�w�肳�ꂽ�^�O�̒��ōł��߂����̂��擾
    GameObject serchTag(GameObject nowObj,string tagName){
        float tmpDis = 0;           //�����p�ꎞ�ϐ�
        float nearDis = 0;          //�ł��߂��I�u�W�F�N�g�̋���
        //string nearObjName = "";    //�I�u�W�F�N�g����
        GameObject targetObj = null; //�I�u�W�F�N�g

        //�^�O�w�肳�ꂽ�I�u�W�F�N�g��z��Ŏ擾����
        foreach (GameObject obs in  GameObject.FindGameObjectsWithTag(tagName)){
            //���g�Ǝ擾�����I�u�W�F�N�g�̋������擾
            tmpDis = Vector3.Distance(obs.transform.position, nowObj.transform.position);

            //�I�u�W�F�N�g�̋������߂����A����0�ł���΃I�u�W�F�N�g�����擾
            //�ꎞ�ϐ��ɋ������i�[
            if (nearDis == 0 || nearDis > tmpDis){
                nearDis = tmpDis;
                //nearObjName = obs.name;
                targetObj = obs;
            }

        }
        //�ł��߂������I�u�W�F�N�g��Ԃ�
        //return GameObject.Find(nearObjName);
        return targetObj;
    }

    public void SetUnit(GameObject unit) {
		this.unit = unit;
	}

    public void SetTower(Transform tower) {
		this.tower = tower;
	}

    public void SetNear(bool near){
        this.near = near;
    }
}