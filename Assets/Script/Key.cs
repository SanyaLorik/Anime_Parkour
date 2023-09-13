using DG.Tweening;
using UnityEngine;

[RequireComponent(typeof(Collider))]
public class Key : MonoBehaviour
{
    [SerializeField] private SimpleChangePreset _preset;

    public bool CanPickedUp { get; private set; } = true;
    
    public void PickUp()
    {
        transform
            .DOScale(Vector3.zero, _preset.Duration)
            .SetEase(_preset.Ease)
            .OnComplete(gameObject.DisactivateSelf);
        
        CanPickedUp = false;
    }
}