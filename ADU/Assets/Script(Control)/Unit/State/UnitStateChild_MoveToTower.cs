using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitStateChild_MoveToTower : StateChildBase
{
    // public GameObject target;
    // [SerializeField] float speed;
    
    private UnityEngine.AI.NavMeshAgent navMeshAgent;
    public Transform enemyTower;
    public Transform playerTower;
    private Transform tower;

    public GameObject unit;

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

        navMeshAgent.destination = enemyTower.position;

        // if(this.gameObject.CompareTag("PlayerUnit")){
        //     navMeshAgent.destination = enemyTower.position;
        // }else if(this.gameObject.CompareTag("EnemyUnit")){
        //     navMeshAgent.destination = playerTower.position;
        // }
    }

    public override void OnExit()
    {
        // Do Nothing.
    }

    public override int StateUpdate()
    {
        // if(this.gameObject.CompareTag("PlayerUnit")){


        // }else if(this.gameObject.CompareTag("EnemyUnit")){


        // return (int)UnitStateController.StateType.Attack;
        return (int)UnitStateController.StateType.MoveToTower;
    }

    public void SetUnit(GameObject unit) {
		this.unit = unit;
	}

    public void SetTower(Transform tower) {
		this.tower = tower;
	}
}