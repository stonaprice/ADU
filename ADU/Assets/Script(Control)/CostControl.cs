using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CostControl : MonoBehaviour
{
    public int cost = 10;
    public GameObject button1;
    public GameObject button2;
    public GameObject button3;
    bool sw;

    void CostOver()
    {
        if(cost <= 0)
        {
            button1.SetActive(false);
        }

        if (cost <= 2)
        {
            button2.SetActive(false);
        }

        if (cost <= 4)
        {
            button3.SetActive(false);
        }
    }

    void CostPay()
    {

    }
}
