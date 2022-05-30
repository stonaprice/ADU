using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitClient : MonoBehaviour
{
    // ステートコントローラー
    [SerializeField] UnitStateController stateController = default;

    [SerializeField] private Transform tower_tmp;
    [SerializeField] private GameObject unit_tmp;


    void Start()
    {
        // var uc = new UnitClient();
        // var mtt = new UnitStateChild_MoveToTower();
        // mtt.SetTower(tower_tmp);
        // mtt.SetUnit(unit_tmp);

        stateController.Initialize((int)UnitStateController.StateType.MoveToTower);
    }

    void Update()
    {
        // stateController.UpdateSequence();
    }

}