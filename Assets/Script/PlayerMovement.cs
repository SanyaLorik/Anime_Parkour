using System;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UIElements;
using Zenject;

[RequireComponent(typeof(CharacterController))]
public class PlayerMovement : MonoBehaviour
{
    [Header("Stats")]
    [SerializeField] private float _speed;

    [Header("Gravity handling")]
    [SerializeField] private float _gravityForce = 9.8f;
    [SerializeField] private float _rayDistance;
    [SerializeField] private Transform _raySource;

    [Header("Movement")]
    [SerializeField] private Vector3 _velocityDirection;

    private CharacterController _character;
    private MovementStoppedMode _stoppedMode;
    
    private void OnDrawGizmos()
    {
        Gizmos.DrawRay(_raySource.position, Vector3.down * _rayDistance);
        
        Gizmos.DrawRay(transform.position, _velocityDirection.normalized * 5);
    }

    private void Awake()
    {
        _character = GetComponent<CharacterController>();
        _stoppedMode.Init();
    }

    private void Update()
    {
        if (_stoppedMode.IsStopped == true)
            return;

        GravityHandling();
        Move();
        Rotate();
    }

    public float GravityForce 
    {
        set 
        { 
            if (value >= 0)
                _gravityForce = value; 
        } 
    }

    public float VelocityDirectionY
    {
        set => _velocityDirection.y = value;
        get
        {
            return _velocityDirection.y;
        }
    }

    public bool CanJump
    {
        get
        {
            return _character.isGrounded == true || Physics.Raycast(_raySource.position, Vector3.down, _rayDistance) == true;
        }
    }

    public void Play()
    {
        _velocityDirection = _stoppedMode.Play();
    }

    public void Stop()
    {
        _stoppedMode.Stop(_velocityDirection);
    }

    private bool CanResetVelocityX
    {
        get
        {
            const float maxY = -0.8f;
            return _velocityDirection.y <= maxY;
        }
    }

    private void Move()
    {
        Vector3 velocity = new()
        {
            x = _velocityDirection.x * _speed,
            y = _velocityDirection.y,
            z = _velocityDirection.z * _speed
        };
        
        _character.Move(velocity * Time.deltaTime);
    }

    private void Rotate()
    {
        Vector3 direction = _velocityDirection;
        direction.y = 0;

        if (direction == Vector3.zero)
            return;

        transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.LookRotation(direction), 360 * Time.deltaTime);
    }

    private void GravityHandling()
    {
        if (_character.isGrounded == true)
        {
            if (CanResetVelocityX == true)
                _velocityDirection.y = 0;
            
            return;
        }
        
        _velocityDirection.y -= _gravityForce * Time.deltaTime;
    }
}

public struct MovementStoppedMode 
{
    private Vector3 _lastVelocityDirection;

    public bool IsStopped { get; private set; }

    public void Init()
    {
        IsStopped = false;
        _lastVelocityDirection = Vector3.zero;
    }

    public Vector3 Play()
    {
        IsStopped = false;
        return _lastVelocityDirection;
    }

    public void Stop(Vector3 velocityDirection)
    {
        _lastVelocityDirection = velocityDirection;
        IsStopped = true;
    }
}