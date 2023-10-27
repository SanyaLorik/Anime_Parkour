using System;
using UnityEngine;

[Serializable]
public struct PrefabUiSpawner
{
    public T Spawn<T>(T prefab, Transform transform) where T : Component
    {
        return UnityEngine.Object.Instantiate(prefab, transform.position, transform.rotation, transform);
    }
}
