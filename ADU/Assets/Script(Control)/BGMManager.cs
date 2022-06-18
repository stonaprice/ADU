using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundStart : MonoBehaviour
{
    public AudioSource audioSource;

    public void SoundPlay()
    {
        audioSource = this.GetComponent<AudioSource>();
        audioSource.Play();
    }

    public void SoundStop()
    {
        audioSource = this.GetComponent<AudioSource>();
        audioSource.Stop();
    }
}
