using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeScene : MonoBehaviour
{
    public void Change()
    {
        //GameOver�V�[���ֈڍs
        FadeManager.Instance.LoadScene("TeamFormation", 1.0f);
    }
}
