using System;
using UnityEngine;

[Serializable]
public struct RangeValue
{
    [field: SerializeField] public float A { get; private set; }
    
    [field: SerializeField] public float B { get; private set; }
}