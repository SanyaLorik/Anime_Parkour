using System;
using UnityEngine;

public class SoleAnimation : MonoBehaviour
{
    [SerializeField] private Animator _animator;
    
    private readonly int _animationHash = Animator.StringToHash("IsDoing");

    public void Animate()
    {
        _animator.SetBool(_animationHash, true);
    }
}