using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour {

    public float span = 3f;
    private float currentTime = 0f;

    void Update () {
        currentTime += Time.deltaTime;

        if(currentTime > span){
            Debug.LogFormat ("{0}秒経過", span);
            currentTime = 0f;
        }
    }
}