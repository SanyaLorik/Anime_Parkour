using System;
using UnityEngine;
using UnityEngine.InputSystem;
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

    private CharacterController _character;
    private PlayerInputSystem _inputSystem;
    [SerializeField]private Vector3 _velocityDirection;
    
    [Inject]
    private void Construct(PlayerInputSystem inputSystem)
    {
        _inputSystem = inputSystem;
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawRay(_raySource.position, Vector3.down * _rayDistance);
    }

    private void Awake()
    {
        _character = GetComponent<CharacterController>();
    }

    private void OnEnable()
    {
        _inputSystem.Player.Move.performed += OnSetDirection;
        _inputSystem.Player.Move.canceled += OnSetDirection;
        
        _inputSystem.Enable();
    }
    
    private void OnDisable()
    {
        _inputSystem.Player.Move.performed -= OnSetDirection;
        _inputSystem.Player.Move.canceled -= OnSetDirection;
        
        _inputSystem.Disable();
    }
    
    private void Update()
    {    
        GravityHandling();
        Move();
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
    
    private bool CanResetVelocityX
    {
        get
        {
            const float maxY = -0.8f;
            return _velocityDirection.y <= maxY;
        }
    }
    
    private void OnSetDirection(InputAction.CallbackContext context)
    { 
        var value = context.ReadValue<Vector2>();
        _velocityDirection = new Vector3()
        {
            x = value.x,
            y = _velocityDirection.y,
            z = value.y,
        };
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