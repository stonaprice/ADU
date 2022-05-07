using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroy : MonoBehaviour
{
    private Rigidbody2D rigidBody;

    private void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
    }

   void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("Unit"))
        {
            other.gameObject.SetActive(false);
        }
    }
}
