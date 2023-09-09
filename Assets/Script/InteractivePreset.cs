using System;
using DG.Tweening;
using UnityEngine;

[Serializable]
public struct InteractivePreset
{
    [field: SerializeField] public Ease Ease { get; private set; }
    
    [field: SerializeField] public Transform Source { get; private set; }
    
    [field: SerializeField] public Transform Target { get; private set; }
    
    [field: SerializeField] public float Duration { get; private set; }
}