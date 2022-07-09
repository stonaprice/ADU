using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;


public class PanelState : MonoBehaviour
{
    [SerializeField] private GameObject Kyu;
    int a = 0;
    public AudioClip open;
    public AudioClip close;
    AudioSource audioSource;

    void Start()
    {
        //Component‚ðŽæ“¾
        audioSource = GetComponent<AudioSource>();
    }

    public void PanelOn()
    {
        var sequence = DOTween.Sequence();
        sequence.Append(Kyu.transform.DOMoveY(105,0.7f));
    }

    public void PanelOff()
    {
        var sequence = DOTween.Sequence();
        sequence.Append(Kyu.transform.DOMoveY(-82,0.7f));
    } 

    public void PanelSlideActive()
    {
        if (a == 1)
        {
            PanelSlidePassive();
        }
        else
        {
            var sequence = DOTween.Sequence();
            sequence.Append(Kyu.transform.DOMoveX(180, 0.7f));
            audioSource.PlayOneShot(open);
            a = 1;
        }
    }

    public void PanelSlidePassive()
    {
        var sequence = DOTween.Sequence();
        sequence.Append(Kyu.transform.DOMoveX(-215,0.7f));
        audioSource.PlayOneShot(close);
        a = 0;
        
    }
}
