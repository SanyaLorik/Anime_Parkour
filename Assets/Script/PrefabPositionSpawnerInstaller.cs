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

public class GroundGenerator : MonoBehaviour
{
    [SerializeField] private GroundDistributor _groundDistributor;
    [SerializeField] private PlayerCollision _playerCollision;

    private void OnEnable()
    {
        _playerCollision.OnTriggerEncountered += OnTeleport;
    }

    private void OnDisable()
    {
        _playerCollision.OnTriggerEncountered -= OnTeleport;
    }

    private void OnTeleport(Transform transform)
    {
        transform.ReciveComponent<Ground>().Correct(_groundDistributor.Push);
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

[RequireComponent(typeof(Collider))]
[RequireComponent(typeof(Rigidbody))]
public class Ground : MonoBehaviour
{

}