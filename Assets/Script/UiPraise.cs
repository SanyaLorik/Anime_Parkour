using DG.Tweening;
using UnityEngine;

public class UiPraise : MonoBehaviour
{
    [SerializeField] private Ease _enablingEase;
    [SerializeField] private float _enablingDuration;

    [SerializeField] private Ease _disablingEase;
    [SerializeField] private float _disablingDuration;

    private void Start()
    {
        Vector3 initalScale = transform.localScale;
        transform.localScale = Vector3.zero;

        Sequence sequence = DOTween.Sequence();
        sequence
            .Append(transform.DOScale(initalScale, _enablingDuration).SetEase(_enablingEase))
            .Append(transform.DOScale(Vector3.zero, _disablingDuration).SetEase(_disablingEase))
            .OnComplete(() => Destroy(gameObject));

        sequence.Play();
    }
}