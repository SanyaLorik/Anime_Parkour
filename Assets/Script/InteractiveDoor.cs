using DG.Tweening;
using UnityEngine;

public class InteractiveDoor : InteractiveObject
{
    [SerializeField] private InteractivePreset _preset;
    
    public override void Interact()
    {
        _preset.Source
            .DOMove(_preset.Target.position, _preset.Duration)
            .SetEase(_preset.Ease);
    }
}