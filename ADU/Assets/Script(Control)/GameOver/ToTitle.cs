using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ToTitle : MonoBehaviour
{
    public void ChangeScene()
    {
        //Titleシーンへ移行
        FadeManager.Instance.LoadScene("Title",1.0f);
    }
}
