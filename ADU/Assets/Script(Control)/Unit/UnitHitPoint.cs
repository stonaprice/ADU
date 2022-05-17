using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UnitHitPoint : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    // ”íƒ_ƒ[ƒWˆ—
    public void Damage(int value)
    {
        if(value <= 0)
        {
            return;
        }

        Hp -= value;

        if(Hp <= 0)
        {
            Dead();
        }
    }
}
