using System;
using UnityEngine;

public class PlayerPraiseDisplayer : MonoBehaviour
{
    [SerializeField] private Transform[] _spawpoints;

    [Header("Jumping")]
    [SerializeField] private UiPraise[] _jumpPraises;
    [SerializeField] private PlayerJumpHandler _jumpHandler;
    [SerializeField][Range(0, 1)] private float _jumpRatio;

    private PrefabUiSpawner _spawner = new();

    private void OnEnable()
    {
        _jumpHandler.OnJumped += OnDisplayJump;
    }

    private void OnDisable()
    {
        _jumpHandler.OnJumped -= OnDisplayJump;
    }

    private void OnDisplayJump()
    {
        var ratio = UnityEngine.Random.Range(0f, 1f);
        if (_jumpRatio < ratio)
            return;

        UiPraise praise = _jumpPraises.GetRandomElement();
        Transform spawnpoint = _spawpoints.GetRandomElement();
        _spawner.Spawn(praise, spawnpoint);
    }
}
