using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Example_ : MonoBehaviour
{
    void Start()
    {
        Handheld.PlayFullScreenMovie("Opening.mp4", Color.black, FullScreenMovieControlMode.CancelOnInput);
    }
}