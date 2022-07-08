using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class FadeLoop : MonoBehaviour
{
    public float tenmetu_ususa;
    public float tenmetu_duration; 


    void Start(){
        var StartButton = GetComponent<Image>();
        StartButton.DOFade(tenmetu_ususa,tenmetu_duration).SetLoops(-1,LoopType.Yoyo);
    }
}
