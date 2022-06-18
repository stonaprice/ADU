using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;


public class PanelState : MonoBehaviour
{
    [SerializeField] private GameObject Kyu;

    public void PanelOn()
    {
        var sequence = DOTween.Sequence();
        sequence.Append(Kyu.transform.DOMoveY(105,0.7f));
    }

    public void PanelOff()
    {
        var sequence = DOTween.Sequence();
        sequence.Append(Kyu.transform.DOMoveY(-82,0.7f));
    } 

    public void PanelSlideActive()
    {
        var sequence = DOTween.Sequence();
        sequence.Append(Kyu.transform.DOMoveX(180,0.7f));
    }

    public void PanelSlidePassive()
    {
        var sequence = DOTween.Sequence();
        sequence.Append(Kyu.transform.DOMoveX(-260,0.7f));
    }
}
