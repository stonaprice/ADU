using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitStateChild_MoveToTower : StateChildBase
{
    private UnityEngine.AI.NavMeshAgent navMeshAgent;

    private Transform tower;
    private GameObject unit;
    private bool near = false;

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
    }

    public override void OnExit()
    {
        // Do Nothing.
    }

    public override int StateUpdate()
    {
        if(near == true){
            return (int)UnitStateController.StateType.MoveToEnemy;
        }

        navMeshAgent.destination = tower.position;

        return (int)UnitStateController.StateType.MoveToTower;

        // if(this.gameObject.CompareTag("PlayerUnit")){
        // }else if(this.gameObject.CompareTag("EnemyUnit")){
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