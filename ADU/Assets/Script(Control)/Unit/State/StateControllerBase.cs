using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class StateControllerBase : MonoBehaviour
{
    protected Dictionary<int, StateChildBase> stateDic = new Dictionary<int, StateChildBase>();

    // 現在のステート
    public int CurrentState { protected set; get; }

    // 初期化処理
    public abstract void Initialize(int initializeStateType);

    // 更新処理
    public void UpdateSequence()
    {
        int nextState = (int)stateDic[CurrentState].StateUpdate();
        AutoStateTransitionSequence(nextState);
    }

    // ステートの自動遷移
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
