using UnityEngine;

[RequireComponent(typeof(Collider))]
[RequireComponent(typeof(Rigidbody))]
public class Trampoline : MonoBehaviour
{
    [Header("Stats")]
    [SerializeField] private float _jumpTime;
    [SerializeField] private float _jumpHeight;
    
    private void OnTriggerEnter(Collider other)
    { 
        other.ReciveComponent<PlayerJumpHandler>().Correct(jumpHandler => jumpHandler.Jump(_jumpTime, _jumpHeight));
    }
}