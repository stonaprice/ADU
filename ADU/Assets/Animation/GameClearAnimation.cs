using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class GameClearAnimation : MonoBehaviour
{
    [SerializeField] private Image Moji1;
    [SerializeField] private Image Moji2;
    [SerializeField] private Image Moji3;
    [SerializeField] private Image Moji4;

    public void TyoKaiSyoBun(){
        ScaledownFadein(Moji1);
        ScaledownFadein(Moji2);
        ScaledownFadein(Moji3);
        ScaledownFadein(Moji4);
    } 

    public void ScaledownFadein(Image image){
        var sequence = DOTween.Sequence();
        /* sequence.Append(image.DOFade(endValue: 0f, duration: 0.2f))
                .Join(image.transform.DOScale(new Vector3(2.72f,2.72f,0),0.2f)); */
            sequence.Append(image.transform.DOLocalMove(new Vector3(120,-50f,0),0.2f));
    }

}
