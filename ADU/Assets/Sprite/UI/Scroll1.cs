using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class Scroll1 : MonoBehaviour
{
    [SerializeField] private float scrollX; 
    [SerializeField] private float scrollY; 
    [SerializeField] private float deadLine; 


    public void Start()
    {
       
                transform.DOLocalMove(new Vector3(scrollX, scrollY, 0f), 1f)
                .SetLoops(-1,LoopType.Yoyo);

    }
}