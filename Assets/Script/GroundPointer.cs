using DG.Tweening;
using UnityEngine;

public class GroundPointer : MonoBehaviour 
{
    [SerializeField] private float _duration;
    [SerializeField] private float _power;
    [SerializeField] private Ease _ease;

    private void Start()
    {
        Vector3 localPosition = transform.localPosition;
        transform.DOLocalJump(localPosition, _power, 1, _duration).SetEase(_ease).SetLoops(-1);
    }
}