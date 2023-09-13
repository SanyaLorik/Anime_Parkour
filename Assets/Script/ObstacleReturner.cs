using UnityEngine;
using Zenject;

[RequireComponent(typeof(Collider))]
[RequireComponent(typeof(Rigidbody))]
public class ObstacleReturner : MonoBehaviour
{
    private StartReturner _returner;

    [Inject]
    private void Construct(StartReturner startReturner)
    {
        _returner = startReturner;
    }
    
    private void OnTriggerEnter(Collider other)
    {
        other.ReciveComponent<PlayerMovement>().Correct(_returner.Return);
    }
}