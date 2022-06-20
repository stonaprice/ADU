using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CostControl : MonoBehaviour
{

    [SerializeField] private float playerCost = 10;
    [SerializeField] private float playerMaxCost = 10;
    [SerializeField] private float enemyCost = 10;
    public GameObject button1;
    public GameObject button2;
    public GameObject button3;

    public CostGaugeAnime CostGaugeAnime;

    public void CostOver()
    {
        if(playerCost < 1)
        {
            button1.SetActive(false);
        }

        if (playerCost < 2)
        {
            button2.SetActive(false);
        }

        if (playerCost < 4)
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
