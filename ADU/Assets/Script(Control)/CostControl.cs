using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CostControl : MonoBehaviour
{

    [SerializeField] private int playerCost = 10;
    [SerializeField] private int enemyCost = 10;
    public GameObject button1;
    public GameObject button2;
    public GameObject button3;

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

    // public void CostPay(int x)
    // {
    //         cost -= x;
    // }

    public void SetPlayerCost(int cost){
        this.playerCost = cost;
    }

    public void SetEnemyCost(int cost){
        this.enemyCost = cost;
    }

    public int GetPlayerCost(){
        return this.playerCost;
    }

    public int GetEnemyCost(){
        return this.enemyCost;
    }
}
