using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundStart : MonoBehaviour
{
    public AudioClip bgm;
    public AudioSource audioSource;

    public void SoundPlay()
    {
        audioSource = gameObject.GetComponent<AudioSource>();
        audioSource.clip = bgm;
        audioSource.Play();
    }

    public void SoundStop()
    {
        audioSource.Stop();
    }
}
