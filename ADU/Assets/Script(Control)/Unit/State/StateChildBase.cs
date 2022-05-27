using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class StateChildBase : MonoBehaviour
{
    // �X�e�[�g�R���g���[���[
    protected StateControllerBase controller;

    // �o�^���ꂽ�X�e�[�g�^�C�v
    protected int StateType { set; get; }

    // ����������
    public virtual void Initialize(int stateType)
    {
        StateType = stateType;
        controller = GetComponent<StateControllerBase>();
    }

    // ���ꏈ��
    public abstract void OnEnter();

    // �ޏꏈ��
    public abstract void OnExit();

    /// �X�V����
    public abstract int StateUpdate();
}
