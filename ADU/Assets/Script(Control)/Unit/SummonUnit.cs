using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SummonUnit : MonoBehaviour
{
    public GameObject Unit1;

    public void UnitSummon()
    {
        //Instantiate( 生成するオブジェクト,  場所, 回転 );  回転はそのままなら↓
        Instantiate(Unit1, new Vector3(-5.0f, 1.0f, -1.5f), Quaternion.identity);
    }
}
