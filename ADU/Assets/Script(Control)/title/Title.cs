using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;//シーンマネジメントを有効にする

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
            SceneManager.LoadScene("Fight");//Fightシーンをロードする
            //
            firstPush = true;
        }
    }

    public void PressQuit()
    {
        Application.Quit();//ゲームプレイ終了
    }
}
