using System;
using DG.Tweening;
using UnityEngine;

[Serializable]
public struct SimpleChangePreset
{
    [field: SerializeField] public Ease Ease { get; private set; }
    
    [field: SerializeField] public float Duration { get; private set; }
}