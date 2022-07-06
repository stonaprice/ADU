using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Totitle : MonoBehaviour
{
    public void Change()
    {
        //GameOverƒV[ƒ“‚ÖˆÚs
        FadeManager.Instance.LoadScene("Title", 1.0f);
    }
}
