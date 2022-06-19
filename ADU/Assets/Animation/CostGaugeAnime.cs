using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using DG.Tweening;

public class CostGaugeAnime : MonoBehaviour
{
    [SerializeField] private GameObject salmon; //ゲェジ
    public CostControl costControl;
    public float rate;

    
    public void gaugeMove(float gauge)
    {
        salmon.GetComponent<Image>().DOFillAmount(gauge, 1.0f);
    }

    public void UnitSummon()
    {
        rate = costControl.GetPlayerCost() / 10;
        gaugeMove(rate);
    }
}