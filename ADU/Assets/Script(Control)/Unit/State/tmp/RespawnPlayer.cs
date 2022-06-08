using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnPlayer : MonoBehaviour
{
    [SerializeField]
    [Tooltip("プレイヤーのプレハブを設定")]
    private GameObject playerPrefab;

    GameObject mainCamera; //Main Cameraそのものが入る変数
    CameraMove script; //CameraMoveScriptが入る変数

    // Update is called once per frame
    void Update()
    {
        // 設定したplayerPrefabと同じ名前(今回は"PlayerSphere")のGameObjectを探して取得
        GameObject playerObj = GameObject.Find(playerPrefab.name);

        // playerObjが存在していない場合
        if (playerObj == null)
        {
            // playerPrefabから新しくGameObjectを作成
            GameObject newPlayerObj = Instantiate(playerPrefab);

            // 新しく作成したGameObjectの名前を再設定(今回は"PlayerSphere"となる)
            newPlayerObj.name = playerPrefab.name;
            // ※ここで名前を再設定しない場合、自動で決まる名前は、"PlayerSphere(Clone)"となるため
            //   13行目で探している"PlayerSphere"が永遠に見つからないことになり、playerが無限に生産される
            //   どういうことかは、22行目をコメントアウトしてゲームを実行すればわかります。

            mainCamera = GameObject.Find ("Main Camera"); //Mein Cameraをオブジェクトの名前から取得して変数に格納する
            script = mainCamera.GetComponent<CameraMove>(); //Main Cameraの中にあるCameraMoveScriptを取得して変数に格納する

            script.SetTarget(newPlayerObj);
        }
    }
}