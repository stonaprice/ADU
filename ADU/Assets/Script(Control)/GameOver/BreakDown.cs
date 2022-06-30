using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class BreakDown : MonoBehaviour
{
    public Explodable explodable;
    [SerializeField] private GameObject Tower;

    public void Explosion()
    {
        explodable.explode();
        this.gameObject.GetComponent<Detonator>().Explode();
    }



    void Destroy()
    {

        /* foreach(Transform child in gameObject.transform)
        {
            Destroy(child.gameObject);
        } */
    }
}