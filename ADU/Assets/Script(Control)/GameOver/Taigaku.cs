using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class Taigaku : MonoBehaviour
{
    public Image taigakusyo;

    void taigakusyoOn()
    {
        Debug.Log("OK");
        this.transform.DOLocalMove(new Vector3(32f, 32f, 0f), 1f);
    }
}
