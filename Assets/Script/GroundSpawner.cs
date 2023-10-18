using UnityEngine;
using Zenject;

public class GroundSpawner : MonoBehaviour
{
    [SerializeField] private Ground[] _prefabs;
    [SerializeField] private Transform _initalPoint;
    [SerializeField] private int _initialCountSpawning;

    private Vector3 _lastPosition = default;
    private PrefabPositionSpawner _spawner;

    public int InitialCountSpawning => _initialCountSpawning;

    [Inject]
    private void Construct(PrefabPositionSpawner spawner)
    {
        _spawner = spawner;
    }

    public void ResetLastPosition()
    {
        _lastPosition = default;
    }

    public Ground Spawn()
    {
        Ground prefab = _prefabs.GetRandomElement();
        Vector3 position = _lastPosition == default ? _initalPoint.position : _lastPosition;

        Ground ground = _spawner.Spawn(prefab, position);

        _lastPosition = ground.RandomNextGroundSpawnpoint;

        return ground;
    }
}