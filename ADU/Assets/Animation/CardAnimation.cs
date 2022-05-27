using DG.Tweening;
using UnityEngine;
using UnityEngine.EventSystems;

public class CardAnimation : UIBehaviour
{
    [SerializeField] private float Rate;
    private Vector3 BaseScale;

    protected override void Start()
    {
        transform.DOLocalRotate(new Vector3(0,0,+Rate),2f);
    }
}
