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

    // private GameObject nearObj;         //最も近いオブジェクト

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
        // //最も近かったオブジェクトを取得
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

    //指定されたタグの中で最も近いものを取得
    GameObject serchTag(GameObject nowObj,string tagName){
        float tmpDis = 0;           //距離用一時変数
        float nearDis = 0;          //最も近いオブジェクトの距離
        //string nearObjName = "";    //オブジェクト名称
        GameObject targetObj = null; //オブジェクト

        //タグ指定されたオブジェクトを配列で取得する
        foreach (GameObject obs in  GameObject.FindGameObjectsWithTag(tagName)){
            //自身と取得したオブジェクトの距離を取得
            tmpDis = Vector3.Distance(obs.transform.position, nowObj.transform.position);

            //オブジェクトの距離が近いか、距離0であればオブジェクト名を取得
            //一時変数に距離を格納
            if (nearDis == 0 || nearDis > tmpDis){
                nearDis = tmpDis;
                //nearObjName = obs.name;
                targetObj = obs;
            }

        }
        //最も近かったオブジェクトを返す
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