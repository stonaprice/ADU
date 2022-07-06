using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Fungus;


public class SkipManager : MonoBehaviour
{
    public GameObject skipButton;
    public Flowchart flowchart;
    public string endBlock;


    public void pushSkipButton()
    {
        Debug.Log("pushed!");
        // スキップボタン無効化
        skipButton.SetActive(false);
        // 現在のブロックを停止する
        flowchart.StopAllBlocks();
        // 会話終了
        flowchart.ExecuteBlock(endBlock);
    }
}
