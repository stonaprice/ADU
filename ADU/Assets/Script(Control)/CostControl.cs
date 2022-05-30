using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CostControl : MonoBehaviour
{

    [SerializeField] private int cost = 10;
    public int x;
    public GameObject button1;
    public GameObject button2;
    public GameObject button3;

    public CostControl costcontrol;

    public void CostOver(int coost)
    {
        if(cost <= 1)
        {
            button1.SetActive(false);
        }

        if (cost <= 3)
        {
            button2.SetActive(false);
        }

        if (cost <= 5)
        {
            button3.SetActive(false);
        }

        CostPay(coost);
    }



    void CostPay(int x)
    {
            cost -= x;
    }

    public void SetCost(int cost){
        this.cost = cost;
    }

    public int GetCost(){
        return this.cost;
    }
}
