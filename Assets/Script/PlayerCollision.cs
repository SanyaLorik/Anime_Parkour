using System;
using UnityEngine;

[RequireComponent(typeof(Collider))]
[RequireComponent(typeof(Rigidbody))]
public class PlayerCollision : MonoBehaviour
{
    public event Action<Transform> OnTriggerEncountered;
    public event Action<Transform> OnColliderEncountered;
    
    private void OnTriggerEnter(Collider other)
    {
        print(other.transform.name);
        OnTriggerEncountered?.Invoke(other.transform);
    }

    private void OnCollisionEnter(Collision collision)
    {
        print(collision.transform.name);
        OnColliderEncountered?.Invoke(collision.transform);
    }
}
