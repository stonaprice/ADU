using DG.Tweening;
using UnityEngine;

public class WaveAnimation : MonoBehaviour
{
    [SerializeField] private Transform WaveTransform;
    void Start()
    {
        WaveTransform.DOScale(Vector3.zero,3f).Play();
    }
}
