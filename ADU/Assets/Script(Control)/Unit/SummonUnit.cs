using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SummonUnit : MonoBehaviour
{
    public GameObject Unit1;
    [SerializeField] private int cost;
    public float vector_x;
    public float vector_y;
    public float vector_z;

    public CostControl costcontrol;


    public void UnitSummon()
    {
        costcontrol.CostOver(cost);
        // costcontrol.cost -= coost;
        Instantiate(Unit1, new Vector3(vector_x, vector_y, vector_z), Quaternion.identity);
        //Instantiate(Unit1, new Vector3(-5.0f, 1.0f, -1.5f), Quaternion.identity);
    }
}
