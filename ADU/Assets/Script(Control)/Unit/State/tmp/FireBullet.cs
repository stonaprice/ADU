using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class FireBullet : MonoBehaviour
{
    [SerializeField]
    [Tooltip("弾の発射場所")]
    private GameObject firingPoint;

    [SerializeField]
    [Tooltip("弾")]
    private GameObject bullet;

    [SerializeField]
    [Tooltip("弾の速さ")]
    private float speed = 10f;
    
    // [SerializeField]
    // [Tooltip("弾の攻撃力")]
    public int attackPower = 1;

    // [SerializeField]
    private UnitStatus unitStatus;

    private float timer = 0;
    private float attackInterval = 1000;

    private GameObject newBall;
    private bool isAttacking = false;
    
    // 弾の発射間隔
    private int shotIntarval = 0;

    // private GameObject[] targets;
    // private GameObject[] targets1;
    // private GameObject[] targets2;
    // private GameObject[] targets3;

    // private bool isSwitch = false;
    // private GameObject closeEnemy;

    // Update is called once per frame
    private void Start()
    {
        unitStatus = this.gameObject.GetComponent<UnitStatus>();
        this.attackPower = unitStatus.AttackPower;
    }

    void Update()
    {
        // 時間を進める
        // shotIntarval++;
        
        // if(attackInterval <= timer){
            // if(isAttacking || Input.GetKeyDown(KeyCode.Space)){
            // if(isAttacking && ReferenceEquals(shotIntarval % 5, 0)){
            if(isAttacking){
                if (this.gameObject.CompareTag("PlayerUnit"))
                {
                    //自身の子オブジェクトから名前検索で取得（一段階下の子オブジェクトのみ）
                    Transform child = this.transform.Find("PlayerBullet");
                    // GameObject child = transform.Find("PlayerBullet").gameObject;
                    if (ReferenceEquals(child, null))
                    {
                        // 弾を発射する
                        LauncherShot();
                    }
                }
                else if (this.gameObject.CompareTag("EnemyUnit"))
                {
                    // 子オブジェクトをタグで検索
                    Transform child = this.transform.Find("EnemyBullet");
                    // GameObject child = transform.Find("EnemyBullet").gameObject;
                    if (ReferenceEquals(child, null))
                    {
                        // 弾を発射する
                        LauncherShot();
                    }
                }

                // isAttacking = false;
            }
        // }

        // timer += Time.deltaTime;

        // if(isSwitch)
        // {
        //     float step = speed * Time.deltaTime;

        //     // ★で得られたcloseEnemyを目的地として設定する。
        //     newBall.transform.position = Vector3.MoveTowards(newBall.transform.position, closeEnemy.transform.position, step);
        // }
    }

    // ReSharper disable Unity.PerformanceAnalysis
    /// <summary>
	/// 弾の発射
	/// </summary>
    // IEnumerator LauncherShot()
    private void LauncherShot()
    {
        // //3秒停止
        // yield return new WaitForSeconds(3);
        
        // 弾を発射する場所を取得
        Vector3 bulletPosition = firingPoint.transform.position;
        // 上で取得した場所に、"bullet"のPrefabを出現させる
        newBall = Instantiate(bullet, bulletPosition, transform.rotation);
        // 弾をユニットの子オブジェクトにする
        newBall.transform.parent = this.transform;
        // 弾に攻撃力を設定する
        newBall.AddComponent<HommingBullet>().attackPower = this.attackPower;
        // // 出現させたボールのforward(z軸方向)
        // Vector3 direction = newBall.transform.forward;
        // // 弾の発射方向にnewBallのz方向(ローカル座標)を入れ、弾オブジェクトのrigidbodyに衝撃力を加える
        // newBall.GetComponent<Rigidbody>().AddForce(direction * speed, ForceMode.Impulse);
        // 出現させたボールの名前を"bullet"に変更
        newBall.name = bullet.name;
        // 出現させたボールを0.8秒後に消す
        Destroy(newBall, 2.0f);
        // Invoke("SwitchOff", 2.0f);


        // // 「初期値」の設定
        // float closeDist = 1000;

        // // タグを使って画面上の全ての敵の情報を取得
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
        //     // コンソール画面での確認用コード
        //     print(Vector3.Distance(newBall.transform.position, t.transform.position));

        //     // このオブジェクト（砲弾）と敵までの距離を計測
        //     float tDist = Vector3.Distance(newBall.transform.position, t.transform.position);

        //     // もしも「初期値」よりも「計測した敵までの距離」の方が近いならば、
        //     if(closeDist > tDist)
        //     {
        //         // 「closeDist」を「tDist（その敵までの距離）」に置き換える。
        //         // これを繰り返すことで、一番近い敵を見つけ出すことができる。
        //         closeDist = tDist;

        //         // 一番近い敵の情報をcloseEnemyという変数に格納する（★）
        //         closeEnemy = t;
        //     }
        // }

        // SwitchOn();
        // // // 砲弾が生成されて0.5秒後に、一番近い敵に向かって移動を開始する。
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
