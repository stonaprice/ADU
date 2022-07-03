using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class GameClearAnimation : MonoBehaviour
{
    public AudioClip se;
    AudioSource audioSource;
    [SerializeField] private GameObject Panel;

    public void TyoKaiSyoBun(){
        audioSource = GetComponent<AudioSource>();
        audioSource.PlayOneShot(se);
        Panel.transform.DOLocalMove(new Vector3(0,0,0),0);
    } 

    public void ScaledownFadein(Image image){
        var sequence = DOTween.Sequence();
        /* sequence.Append(image.DOFade(endValue: 0f, duration: 0.2f))
                .Join(image.transform.DOScale(new Vector3(2.72f,2.72f,0),0.2f)); */
            sequence.Append(image.transform.DOLocalMove(new Vector3(120,-50f,0),0.2f));
    }

}
