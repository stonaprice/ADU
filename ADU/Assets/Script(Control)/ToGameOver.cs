using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ToGameOver : MonoBehaviour
{
    /*public void GameOver()
    {
        Invoke("ChangeScene", 1.0f);
    }*/

    public void ChangeScene()
    {
        //GameOverシーンへ移行
        FadeManager.Instance.LoadScene("GameOver", 1.0f);
    }

    public void ChangeClearScene()
    {
        //GameOverシーンへ移行
        FadeManager.Instance.LoadScene("GameClear", 1.0f);
    }

}
