using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlayer : MonoBehaviour
{
    public GameObject target;
    public float speed;
    public bool isTouch;

    void Start()
    {
        speed = 0.005f;
        target = GameObject.Find("GameObject");
        bool isTouch = false;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.name == "GameObject")
        {
            bool isTouch = true;
        }
    }

    void Update()
    {
        if(isTouch == false)
        {
            transform.position = Vector3.MoveTowards(transform.position, target.transform.position, speed);
        }
    }
}
