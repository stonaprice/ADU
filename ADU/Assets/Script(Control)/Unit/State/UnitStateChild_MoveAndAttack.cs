using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class UnitStateChild_MoveAndAttack : StateChildBase
{
    private UnityEngine.AI.NavMeshAgent navMeshAgent;

    private Transform tower;
    private GameObject unit;
    private bool isFinding = false;
    private float findDistance = 10;
    
    // private UnitStatus unitStatus = GetComponentInParent<UnitStatus>();
    // private float findDistance = unitStatus.FindDistance;

    private GameObject closeEnemy = null;

    private GameObject[] targets1;
    private GameObject[] targets2;
    private GameObject[] targets3;

    // 「初期値」の設定
    private float closeDist = 1000;

    // private GraphicsBuffer.Target _target;
    
    FireBullet fb;

    public override void OnEnter()
    {
        Debug.Log("MoveAndAttack");
        // navMeshAgent = GetComponent<UnityEngine.AI.NavMeshAgent>(); // NavMeshAgent

        navMeshAgent = unit.GetComponent<UnityEngine.AI.NavMeshAgent>();
        navMeshAgent.destination = tower.position;
        
        navMeshAgent.speed = GetComponentInParent<UnitStatus>().MoveSpeed;
        isFinding = false;
        
        fb = GetComponentInParent<FireBullet>();
    }

    public override void OnExit()
    {
        // navMeshAgent.speed = 0f;
    }

    public override int StateUpdate()
    {
        // タグを使って画面上の全ての敵の情報を取得
        if(this.gameObject.CompareTag("PlayerUnit")){
            // targets1 = GameObject.FindGameObjectsWithTag("Enemy");
            targets2 = GameObject.FindGameObjectsWithTag("EnemyUnit");
            targets3 = GameObject.FindGameObjectsWithTag("EnemyTower");
        }
        else if (this.gameObject.CompareTag("EnemyUnit"))
        {
            targets1 = GameObject.FindGameObjectsWithTag("Player");
            targets2 = GameObject.FindGameObjectsWithTag("PlayerUnit");
            targets3 = GameObject.FindGameObjectsWithTag("PlayerTower");
        }

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
            
            // 一番近い敵や塔に向かって移動します。
            // navMeshAgent.SetDestination(closeEnemy.transform.position);
            navMeshAgent.destination = closeEnemy.transform.position;
        }

        if(isFinding){
            fb.SetIsAttacking(true);
        }
        else
        {
            fb.SetIsAttacking(false);
        }

        return (int)UnitStateController.StateType.MoveAndAttack;
    }

    void SearchNearest(GameObject t){
        // // コンソール画面での確認用コード
        // print(Vector3.Distance(transform.position, t.transform.position));
        if(t){
            // このオブジェクト（砲弾）と敵までの距離を計測
            float tDist = Vector3.Distance(transform.position, t.transform.position);

            // もしも「初期値」よりも「計測した敵までの距離」の方が近いならば、
            if(closeDist > tDist)
            {
                // 「closeDist」を「tDist（その敵までの距離）」に置き換える。
                // これを繰り返すことで、一番近い敵を見つけ出すことができる。
                closeDist = tDist;

                // 一番近い敵の情報をcloseEnemyという変数に格納する（★）
                closeEnemy = t;
            }
        }
    }

    void CheckDistance()
    {
        // プレイヤーまでの距離（二乗された値）を取得
        // sqrMagnitudeは平方根の計算を行わないので高速。距離を比較するだけならそちらを使った方が良い
        float diff = (closeEnemy.transform.position - this.transform.position).sqrMagnitude;
        // 距離を比較。比較対象も二乗するのを忘れずに
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