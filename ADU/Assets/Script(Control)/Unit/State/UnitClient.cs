using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitClient : MonoBehaviour
{
    // �X�e�[�g�R���g���[���[
    [SerializeField] UnitStateController stateController = default;

    [SerializeField] private Transform tower;
    [SerializeField] private GameObject unit;

    void Start()
    {
        stateController.SetTower(tower);
        stateController.SetUnit(unit);

        stateController.Initialize((int)UnitStateController.StateType.MoveToTower);
    }

    void Update()
    {
        stateController.UpdateSequence();
    }

    // // �߂��ɓG������ꍇ
    // public void OnDetectObject(Collider collider)
    // {
    //     Debug.Log("sekkin");
    //     // �����I�u�W�F�N�g���̑��̃X�N���v�g���Q�Ƃ���ꍇ

    //     Debug.Log(collider.tag);
    // }
}