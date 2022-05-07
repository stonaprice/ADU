using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HommingEnemy : MonoBehaviour
{
    public float speed;
    private GameObject[] targets;
    private bool isSwitch = false;

    private GameObject closeEnemy;

    private void Start()
    {
        targets = GameObject.FindGameObjectsWithTag("Enemy");

        float closeDist = 1000;

        foreach(GameObject t in targets)
        {
            print(Vector3.Distance(transform.position, t.transform.position));

            float tDist = Vector3.Distance(transform.position, t.transform.position);

            if(closeDist > tDist)
            {
                closeDist = tDist;

                closeEnemy = t;
            }
        }

        Invoke("SwitchOn",0.5f);
    }

    void Update()
    {
        if(isSwitch)
        {
            float step = speed * Time.deltaTime;

            transform.position = Vector3.MoveTowards(transform.position, closeEnemy.transform.position, step);

        }
    }

    void SwitchOn()
    {
        isSwitch = true;
    }
}
