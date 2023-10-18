using DG.Tweening;
using UnityEngine;

[RequireComponent(typeof(Collider))]
[RequireComponent(typeof(Rigidbody))]
public class Ground : MonoBehaviour
{
    [SerializeField] private Transform[] _nextGroundSpawnpoints;
    [SerializeField] private Ease _ease;
    [SerializeField] private float _duration;

    private void Start()
    {
        Vector3 localScale = transform.localScale;
        transform.localScale = Vector3.zero;
        transform.DOScale(localScale, _duration).SetEase(_ease);
    }

    public Vector3 RandomNextGroundSpawnpoint => _nextGroundSpawnpoints.GetRandomElement().position;

    public bool WasHaving { get; private set; } = false;

    public void SetHaving()
    {
        WasHaving = true;
    }
}
