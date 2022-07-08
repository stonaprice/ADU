using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;//シーンマネジメントを有効にする
using DG.Tweening;
using UnityEngine.UI;

public class Title : MonoBehaviour
{
    private bool firstPush = false;
    

    public void PressStart()
    {
        Debug.Log("Press Start!");
        if (!firstPush)
        {
            Debug.Log("Go Next Scene!");
            //ここに次のシーンへいく命令を書く
            FadeManager.Instance.LoadScene("Start", 1.0f);//Fightシーンをロードする
            //
            firstPush = true;
        }
    }

    public void PressQuit()
    {
        Application.Quit();//ゲームプレイ終了
    }

    public void FadeLoop(){
        var StartButton = GetComponent<Image>();
        StartButton.DOFade(0.2f,1.5f)
                    .SetLoops(-1,LoopType.Yoyo);
    }
}
