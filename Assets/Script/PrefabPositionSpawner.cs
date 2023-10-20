using System;
using UnityEngine;

[Serializable]
public struct PrefabPositionSpawner
{
    [SerializeField] private Transform _container;

    public T Spawn<T>(T prefab, Vector3 position) where T : Component
    {
        return UnityEngine.Object.Instantiate(prefab, position, prefab.transform.rotation, _container);
    }
}