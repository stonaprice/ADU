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

    // 「初期値」の設定
    private float closeDist = 1000;

    private void Start()
    {
        // タグを使って画面上の全ての敵の情報を取得
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

        // // 「初期値」の設定
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
        // // 砲弾が生成されて0.5秒後に、一番近い敵に向かって移動を開始する。
        // Invoke("SwitchOn", 0.5f);
    }

    void Update()
    {
        if(isSwitch){
            // closeEnemyがない場合Startに戻る
            if(!closeEnemy){
                Start();
            }else{
                float step = speed * Time.deltaTime;

                // ★で得られたcloseEnemyを目的地として設定する。
                transform.position = Vector3.MoveTowards(transform.position, closeEnemy.transform.position, step);
            }
        }
    }

    void SearchNearest(GameObject t){

        if(t){
            // コンソール画面での確認用コード
            print(Vector3.Distance(transform.position, t.transform.position));
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

    void SwitchOn()
    {
        isSwitch = true;
    }
}