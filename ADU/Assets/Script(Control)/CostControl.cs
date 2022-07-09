using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CostControl : MonoBehaviour
{

    [SerializeField] private float playerCost = 10;
    [SerializeField] private float playerMaxCost = 10;
    public float PlayerMaxCost
    {
        get { return this.playerMaxCost; }
        set => this.playerMaxCost = value;
    }
    [SerializeField] private float enemyCost = 10;
    public GameObject button1;
    public GameObject button2;
    public GameObject button3;
    private float _button1Cost;
    private float _button2Cost;
    private float _button3Cost;

    public CostGaugeAnime CostGaugeAnime;

    private void Start()
    {
        _button1Cost = button1.AddComponent<UnitStatus>().UnitCost;
        _button2Cost = button2.AddComponent<UnitStatus>().UnitCost;
        _button3Cost = button3.AddComponent<UnitStatus>().UnitCost;
    }

    public void CostOver()
    {
        if(playerCost < _button1Cost)
        {
            button1.SetActive(false);
        }

        if (playerCost < _button2Cost)
        {
            button2.SetActive(false);
        }

        if (playerCost < _button3Cost)
        {
            button3.SetActive(false);
        }
    }

    public void ActivButton(){
        button1.SetActive(true);
        button2.SetActive(true);
        button3.SetActive(true);
    }

    public void CostAnimation(){
      CostGaugeAnime.gaugeMove(playerCost/playerMaxCost);
    }

    // public void CostPay(int x)
    // {
    //         cost -= x;
    // }

    public void SetPlayerCost(float cost){
        this.playerCost = cost;
    }

    public void SetEnemyCost(float cost){
        this.enemyCost = cost;
    }

    public float GetPlayerCost(){
        return this.playerCost;
    }

    public float GetEnemyCost(){
        return this.enemyCost;
    }
}
