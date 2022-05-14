using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 
public class MousePoint : MonoBehaviour
{
    private Vector3 mousePosition;
    private Vector3 objPosition;
 
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            mousePosition = Input.mousePosition;
            mousePosition.z = 10.0f;
            objPosition = Camera.main.ScreenToWorldPoint(mousePosition);
            this.transform.position = new Vector3(objPosition.x, 0 ,0);
        }
    }
}