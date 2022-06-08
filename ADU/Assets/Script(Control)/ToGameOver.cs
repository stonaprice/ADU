using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ToGameOver : MonoBehaviour
{
    public void GameOver()
    {
        Invoke("ChangeScene", 1.0f);
    }

    public void ChangeScene()
    {
        //GameOver�V�[���ֈڍs
        FadeManager.Instance.LoadScene("GameOver", 0.3f);
    }
}
