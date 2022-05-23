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
        //GameOverƒV[ƒ“‚ÖˆÚs
        SceneManager.LoadScene("GameOver");
    }
}
