using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveToTarget : MonoBehaviour
{
    public GameObject target;
    [SerializeField] float speed;

    void Update()
    {
        float step = speed * Time.deltaTime;


        //自分の位置、ターゲット、速度
        transform.position = Vector3.MoveTowards(transform.position, target.transform.position, step);
    }
}
