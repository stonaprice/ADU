using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitClient : MonoBehaviour
{
    // ステートコントローラー
    [SerializeField] UnitStateController stateController = default;

    [SerializeField] private Transform tower_tmp;
    [SerializeField] private GameObject unit_tmp;
    public UnitStateChild_MoveToTower USTMTT;


    void Start()
    {
        USTMTT.SetTower(tower_tmp);
        USTMTT.SetUnit(unit_tmp);

        stateController.Initialize((int)UnitStateController.StateType.MoveToTower);
    }

    void Update()
    {
        // stateController.UpdateSequence();
    }

}