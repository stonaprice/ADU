using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGMManager : MonoBehaviour
{
    public AudioClip bgm;
    public AudioSource audioSource;

    void SoundPlay()
    {
        audioSource = gameObject.GetComponent<AudioSource>();
        audioSource.clip = bgm;
        audioSource.Play();
    }

    void SoundStop()
    {
        audioSource.Stop();
    }
}
