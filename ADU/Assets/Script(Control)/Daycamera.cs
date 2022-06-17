using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Daycamera : MonoBehaviour
{
    void Update () {
        // transformを取得
        Transform myTransform = this.transform;
 
        Vector3 worldAngle = myTransform.eulerAngles;
        worldAngle.y += 0.01f; 
        myTransform.eulerAngles = worldAngle; 
    }
}
