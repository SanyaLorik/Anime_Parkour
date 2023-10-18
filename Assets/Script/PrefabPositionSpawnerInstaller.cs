using System;
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

public class GroundPlacer : MonoBehaviour
{

}

public class GroundDistributor : MonoBehaviour
{
    [SerializeField] private GroundPlacer _groundPlacer;

    public void Push(Ground ground)
    {

    }

    public void Get()
    {

    }
}
