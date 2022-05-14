using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public Rigidbody rb;
    public Vector3 moving, latestPos;
    public float jumpPower;
    public bool isGround;
    public float speed;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        isGround = false;
    }

    void Update()
    {
        MovementControll();
        Movement();
        
        if(isGround){
            rb.AddForce(transform.up * jumpPower, ForceMode.Impulse);
        }
        
    }


    void MovementControll()
    {
        moving = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical"));
        moving.Normalize();
        moving = moving * speed;
    }



    void Movement()
    {
        rb.velocity = moving;
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "w" )
        {
           isGround = true;
        }
    }
 
    void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.name == "w" )
        {
           isGround = false;
        }
    }

}
