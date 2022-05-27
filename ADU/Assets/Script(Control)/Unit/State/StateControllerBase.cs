using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class StateControllerBase : MonoBehaviour
{
    protected Dictionary<int, StateChildBase> stateDic = new Dictionary<int, StateChildBase>();

    // ���݂̃X�e�[�g
    public int CurrentState { protected set; get; }

    // ����������
    public abstract void Initialize(int initializeStateType);

    // �X�V����
    public void UpdateSequence()
    {
        int nextState = (int)stateDic[CurrentState].StateUpdate();
        AutoStateTransitionSequence(nextState);
    }

    // �X�e�[�g�̎����J��
    protected void AutoStateTransitionSequence(int nextState)
    {
        if (CurrentState == nextState)
        {
            return;
        }

        stateDic[CurrentState].OnExit();
        CurrentState = nextState;
        stateDic[CurrentState].OnEnter();
    }
}
