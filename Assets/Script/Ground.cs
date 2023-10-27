using DG.Tweening;
using System;
using UnityEngine;

[RequireComponent(typeof(Collider))]
[RequireComponent(typeof(Rigidbody))]
public class Ground : MonoBehaviour
{
    [Header("Next prefabs")]
    [SerializeField] private Transform[] _nextGroundSpawnpoints;
    [SerializeField] private Ease _ease;
    [SerializeField] private float _duration;

    [Header("Decorations")]
    [SerializeField] private GameObject[] _decorations;
    [SerializeField][Range(0f, 1f)] private float _percentActivator;

    private void Start()
    {
        AnimateInstantiation();
        ActivateDecorations();
    }

    public Vector3 RandomNextGroundSpawnpoint => _nextGroundSpawnpoints.GetRandomElement().position;

    public bool WasHaving { get; private set; } = false;

    public void SetHaving()
    {
        WasHaving = true;
    }

    private void AnimateInstantiation()
    {
        Vector3 localScale = transform.localScale;
        transform.localScale = Vector3.zero;
        transform.DOScale(localScale, _duration).SetEase(_ease);
    }

    private void ActivateDecorations()
    {
        _decorations
            .GetRandomElementsByPercent(_percentActivator, true)
            .ActivateArraySelf();
    }
}
