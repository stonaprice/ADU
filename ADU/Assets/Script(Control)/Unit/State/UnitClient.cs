using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitClient : MonoBehaviour
{
    // �X�e�[�g�R���g���[���[
    [SerializeField] UnitStateController stateController = default;

    void Start()
    {
        stateController.Initialize((int)UnitStateController.StateType.MoveToTower);
    }

    void Update()
    {
        stateController.UpdateSequence();
    }

}
