using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyChase : MonoBehaviour
{
    private GameObject target;
    public float speed;

    void Start()
    {
        speed = 0.05f;
        target = GameObject.Find("Player");
    }

    //���������ǂ��܂������Ȃ��B�����炭����Player�����o������Ƃ������������܂������ĂȂ��C������B

    void Update()
    {
        if (target.GetComponent<MovePlayer>().isArea == true)
        {
            transform.LookAt(target.transform);
            transform.position += transform.forward * speed;
        }
        else
        {
            GetComponent<Renderer>().material.color = Color.white;
        }
    }
}
