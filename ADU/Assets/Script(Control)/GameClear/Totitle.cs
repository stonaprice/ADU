using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Totitle : MonoBehaviour
{
    public void Change()
    {
        //GameOverシーンへ移行
        FadeManager.Instance.LoadScene("Title", 1.0f);
    }
}
