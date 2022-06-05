using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class TanbaCutIn_test : MonoBehaviour
{
    [SerializeField] private RectTransform crown;
    [SerializeField] private RectTransform lights;

    private const float UP_POS = 1000f;


    private void Start()
    {
        PlayAnimation();
    }

    /// <summary>
    /// アニメーションを再生
    /// </summary>
    private void PlayAnimation()
    {
        var param = new TweenParams().SetLoops(-1, LoopType.Yoyo).SetEase(Ease.InOutSine);
        
        DOTween.Sequence()
            .Join(crown.DOAnchorPosY(UP_POS, 0))
            .Join(lights.DOScale(0, 0))
            .AppendInterval(0.1f)
            .Append(crown.DOAnchorPosY(0, 0.4f))
            .Join(crown.DOLocalRotate(Vector3.forward * -2f, 0.4f))
            .AppendCallback(() =>
            {
                DOTween.Sequence()
                    .Append(crown.DOAnchorPosY(30f, 0.8f))
                    .SetAs(param);
                crown.DOLocalRotate(Vector3.forward * 2f, 0.55f).SetAs(param);
            })
            .Append(lights.DOScale(1, 0.4f))
            .AppendCallback(() =>
            {
                lights.DOLocalRotate(Vector3.back * 180f, 5f)
                    .SetEase(Ease.Linear)
                    .SetLoops(-1);
            });
            
            
    }
    
}