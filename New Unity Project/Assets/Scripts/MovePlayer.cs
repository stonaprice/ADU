using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlayer : MonoBehaviour
{
    public GameObject target;
    public float speed;
    public bool isTouch;
    public bool isArea;

    void Start()
    {
        speed = 0.005f;
        target = GameObject.Find("Mouse");
        isTouch = false;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Mouse")
        {
            isTouch = true;
        }
    }

    void Update()
    {
        if (isTouch == false)
        {
            transform.position = Vector3.MoveTowards(transform.position, target.transform.position, speed);
        }
    }

    void OnTriggerStay(Collider other)
    {
        if (other.gameObject.name == "EnemyArea")
        {
            isArea = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.name == "EnemyArea")
        {
            isArea = false;
        }
    }
}
