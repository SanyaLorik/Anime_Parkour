using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(CharacterController))]
public class PlayerMovement : MonoBehaviour
{
    [Header("Stats")]
    [SerializeField] private float _speed;

    [Header("Gravity handling")]
    [SerializeField] private float _gravityForce = 9.8f;

    private CharacterController _character;
    private PlayerInputSystem _inputSystem;
    private Vector3 _velocityDirection;
    
    private void Awake()
    {
        _character = GetComponent<CharacterController>();
        _inputSystem = new();
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
        set 
        { 
            _velocityDirection.y = value; 
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
            return;
        
        _velocityDirection.y -= _gravityForce * Time.deltaTime;
    }
}