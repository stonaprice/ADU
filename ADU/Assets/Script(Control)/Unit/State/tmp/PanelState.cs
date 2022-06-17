using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;


public class PanelState : MonoBehaviour
{
    [SerializeField] private GameObject Kyu;

    private void PanelOn()
    {
        var sequence = DOTween.Sequence();
        sequence.Append(Kyu.transform.DOMoveY(105,0.7f));
    }

    private void PanelOff()
    {
        var sequence = DOTween.Sequence();
        sequence.Append(Kyu.transform.DOMoveY(-82,0.7f));
    } 
}
