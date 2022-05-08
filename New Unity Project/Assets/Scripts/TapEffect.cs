using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TapEffect : MonoBehaviour
{
    public GameObject prefab;
    public float deleteTime = 1.0f;

    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            var mousePosition = Input.mousePosition;
            mousePosition.z = 3f;

            GameObject clone = Instantiate(prefab, Camera.main.ScreenToWorldPoint(mousePosition), Quaternion.identity);
            Destroy(clone, deleteTime);
        }
    }
}
