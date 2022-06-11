using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;


public class StartScene : MonoBehaviour
{
    [SerializeField] private GameObject Cube;
    [SerializeField] private GameObject Panel1;
    [SerializeField] private GameObject Panel2;


    private void PlayAnimation()
    { 
        var sequence = DOTween.Sequence(); //Sequence生成
        sequence.SetEase(Ease.InQuad)
                .Append(Cube.transform.DOLocalMoveY(0,0.7f)).SetEase(Ease.Linear)
                .Insert(0,Cube.transform.DOScale(new Vector3(0.45f,1,1),0.5f))
                .Insert(0.5f,Cube.transform.DOScale(new Vector3(1.1f,0.5f),0.2f)).SetEase(Ease.InQuad)
                .Append(Cube.transform.DOLocalMoveY(200,0.4f)).SetEase(Ease.Linear)
                .Insert(0.7f,Cube.transform.DOScale(new Vector3(0.4f,1.1f),0.3f)).SetEase(Ease.OutQuad)
                .Insert(1.0f,Cube.transform.DOScale(new Vector3(1f,1f),0.3f)).SetEase(Ease.InQuad)
                .Append(Cube.transform.DOLocalMoveY(0,0.5f))
                .Insert(1.3f,Cube.transform.DOScale(new Vector3(0.5f,1f),0.2f))
                .Insert(1.5f,Cube.transform.DOScale(new Vector3(1f,0.5f),0.2f))
                .Append(Cube.transform.DOLocalMoveY(0,1.5f))
                .Insert(1.7f,Cube.transform.DOScale(new Vector3(1f,1f),0.2f));

        sequence.Join(Cube.transform.DOLocalMoveX(1000,1.7f)).SetEase(Ease.InOutCubic)
                .Join(Panel1.transform.DOLocalMoveX(1000,1.7f)).SetEase(Ease.InOutCubic)
                .Join(Panel2.transform.DOLocalMoveX(-1000,1.7f)).SetEase(Ease.InOutCubic);   
    }

    private void Hinanjo()
    {
        var sequence = DOTween.Sequence();
        sequence.SetEase(Ease.InQuad)
                .Append(Cube.transform.DOLocalMoveY(0,0.7f)).SetEase(Ease.Linear)
                .Insert(0,Cube.transform.DOScale(new Vector3(0.45f,1,1),0.5f))
                .Insert(0.5f,Cube.transform.DOScale(new Vector3(1.1f,0.5f),0.2f)).SetEase(Ease.InQuad)
                .Append(Cube.transform.DOLocalMoveY(200,0.4f)).SetEase(Ease.Linear)
                .Insert(0.7f,Cube.transform.DOScale(new Vector3(0.4f,1.1f),0.3f)).SetEase(Ease.OutQuad)
                .Insert(1.0f,Cube.transform.DOScale(new Vector3(1f,1f),0.3f)).SetEase(Ease.InQuad)
                .Insert(1.3f,Cube.transform.DOScale(new Vector3(0.5f,1f),0.2f))
                .Append(Cube.transform.DOLocalMoveY(0,0.5f))
                .Append(Cube.transform.DOLocalMoveY(100,0.5f))
                .Insert(1.5f,Cube.transform.DOScale(new Vector3(1f,0.5f),0.2f))
                .Insert(1.7f,Cube.transform.DOScale(new Vector3(1f,1f),0.2f))
                .SetEase(Ease.InQuad);
    }
}
