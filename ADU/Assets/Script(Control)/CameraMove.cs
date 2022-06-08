using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 
public class CameraMove : MonoBehaviour
{
    [SerializeField]
    private GameObject target;
    private Vector3 distance;
 
    void Start()
    {
        distance = transform.position - target.transform.position;
    }
 
    void LateUpdate()
    {
        transform.position = target.transform.position + distance;
    }

    public void SetTarget(GameObject target){
        this.target = target;
    }
}