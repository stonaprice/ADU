using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ToTeamformation : MonoBehaviour
{
    public void ChangeScene()
    {
        //GameOverシーンへ移行
        FadeManager.Instance.LoadScene("TeamFormation", 1.0f);
    }
}
