using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitClient : MonoBehaviour
{
    // ステートコントローラー
    [SerializeField] UnitStateController stateController = default;

    [SerializeField] private Transform tower;
    [SerializeField] private GameObject unit;

    void Start()
    {
        stateController.SetTower(tower);
        stateController.SetUnit(unit);

        // ３回目
        stateController.Initialize((int)UnitStateController.StateType.MoveAndAttack);
        // // ２回目
        // stateController.Initialize((int)UnitStateController.StateType.Move);
        // // １回目
        // stateController.Initialize((int)UnitStateController.StateType.MoveToTower);
    }

    void Update()
    {
        stateController.UpdateSequence();
    }

    // // 近くに敵がいる場合
    // public void OnDetectObject(Collider collider)
    // {
    //     Debug.Log("sekkin");
    //     // 同じオブジェクト内の他のスクリプトを参照する場合

    //     Debug.Log(collider.tag);
    // }
}