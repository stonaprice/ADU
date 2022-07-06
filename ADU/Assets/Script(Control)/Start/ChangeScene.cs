using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeScene : MonoBehaviour
{
    public void Change()
    {
        //GameOverƒV[ƒ“‚ÖˆÚs
        FadeManager.Instance.LoadScene("TeamFormation", 1.0f);
    }
}
