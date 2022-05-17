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


        //�����̈ʒu�A�^�[�Q�b�g�A���x
        transform.position = Vector3.MoveTowards(transform.position, target.transform.position, step);
    }
}
