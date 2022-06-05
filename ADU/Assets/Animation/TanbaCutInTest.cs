using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class TanbaCutInTest : MonoBehaviour
{
    [SerializeField] private GameObject Character;
    [SerializeField] private GameObject Panel;
    [SerializeField] private GameObject Sword;
    

    private void Cutin()
    {
        CutinCharacter();
        CutinBackGround();        
        CutinSword();
    }

    private void CutinCharacter()
    {
        var sequence = DOTween.Sequence(); //Sequence生成
        //Tweenをつなげる
        sequence.Append(Character.transform.DOLocalMove(new Vector3(500, 0, 0), 1f))
                .Append(Character.transform.DOLocalMove(new Vector3(300, 0, 0), 1f))
                .AppendInterval(0.25f)
                .Append(Character.transform.DOLocalMove(new Vector3(-1500, 0, 0), 1f));
    }

    private void CutinBackGround()
    {
        Transform myTransform = Panel.transform;
        Vector3 panelscale = myTransform.localScale;
        
        var sequence2 = DOTween.Sequence();
        sequence2.AppendInterval(0.2f)
                .Append(Panel.transform.DOScale(new Vector3(panelscale.x, 1.5f , panelscale.z), 1f))
                .AppendInterval(0.5f)
                .Append(Panel.transform.DOScale(new Vector3(panelscale.x, 0 , panelscale.z), 1f));

    }

    private void CutinSword()
    {
         var sequence3 = DOTween.Sequence();
                sequence3.AppendInterval(0.2f)
                        .Append(Sword.transform.DOLocalMove(new Vector3(0, 0, 0), 1f))
                        .Append(Sword.transform.DOScale(new Vector3(12,9,12), 1f))
                        .Append(Sword.transform.DOShakeScale(
                            duration: 1f,
                            strength: 2.2f
                        ))
                        .Append(Sword.transform.DOScale(new Vector3(0,0,0), 0.1f));
    }
}