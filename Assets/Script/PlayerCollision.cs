using System;
using UnityEngine;

[RequireComponent(typeof(Collider))]
[RequireComponent(typeof(Rigidbody))]
public class PlayerCollision : MonoBehaviour
{
    public event Action<Transform> OnTriggerEncountered;
    
    private void OnTriggerEnter(Collider other)
    { 
        OnTriggerEncountered?.Invoke(other.transform);
    }
}