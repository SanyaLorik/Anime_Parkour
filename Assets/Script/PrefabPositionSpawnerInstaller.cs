using UnityEngine;
using Zenject;

public class PrefabPositionSpawnerInstaller : MonoInstaller
{
    [SerializeField] private PrefabPositionSpawner _spawner;
    
    public override void InstallBindings()
    {
        Container
            .Bind<PrefabPositionSpawner>()
            .FromInstance(_spawner)
            .AsCached();
        
        Debug.Log("PrefabPositionSpawnerInstaller is installed.");
    }
}
