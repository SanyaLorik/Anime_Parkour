using System;
using System.Collections.Generic;
using UnityEngine;

public class GroundGenerator : MonoBehaviour
{
    [SerializeField] private GroundSpawner _spawner;
    [SerializeField] private PlayerCollision _playerCollision;

    private readonly List<Ground> _grounds = new();

    private void OnEnable()
    {
        _playerCollision.OnTriggerEncountered += OnSpawned;
    }

    private void OnDisable()
    {
        _playerCollision.OnTriggerEncountered -= OnSpawned;
    }

    public void GenerateFirts()
    {
        _spawner.ResetLastPosition();
        LoopExtension.RepeatMethod(_spawner.InitialCountSpawning, () => _grounds.Add(_spawner.Spawn()));
    }

    public void DestroyAllGrounds()
    {
        print(_grounds.Count);
        _grounds.DestroyArrayGameobjectsSelf();
        _grounds.Clear();
    }

    private void OnSpawned(Transform transform)
    {
        transform.ReciveComponent<Ground>().IsCorrect(ground => ground.WasHaving == false).Correct(ground =>
        {
            ground.SetHaving();
            _grounds.Add(_spawner.Spawn());
        });
    }
}
