using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SummonUnit : MonoBehaviour
{
    public GameObject Unit1;

    public void UnitSummon()
    {
        //Instantiate( ��������I�u�W�F�N�g,  �ꏊ, ��] );  ��]�͂��̂܂܂Ȃ火
        Instantiate(Unit1, new Vector3(-5.0f, 1.0f, -1.5f), Quaternion.identity);
    }
}
