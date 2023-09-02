using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(CharacterController))]
[RequireComponent(typeof(PlayerMovement))]
public class PlayerJumpHandler : MonoBehaviour
{
    [Header("Jump stats")]
    [SerializeField] private float _maxJumpTime;
    [SerializeField] private float _maxJumpHeight;

    private PlayerMovement _movement;
    private CharacterController _controller;
    private PlayerInputSystem _inputSystem;
    
    private void Awake()
    {
        _movement = GetComponent<PlayerMovement>();
        _controller = GetComponent<CharacterController>();

        _inputSystem = new();
    }
    
    private void OnEnable()
    {
        _inputSystem.Player.Jump.performed += OnJump;
        
        _inputSystem.Enable();
    }

    private void OnDisable()
    {
        _inputSystem.Player.Jump.performed -= OnJump;
        
        _inputSystem.Disable();
    }
    
    private float JumpVelocity
    {
        get
        {
            float maxHeightTime = _maxJumpTime / 2;
            _movement.GravityForce = (2 * _maxJumpHeight) / Mathf.Pow(maxHeightTime, 2);
            return (2 * _maxJumpHeight) / maxHeightTime;
        }
    }
    
    private void OnJump(InputAction.CallbackContext _)
    {
        Jump();
    }

    private void Jump()
    {
        if (_controller.isGrounded == false)
            return;
        
        _movement.VelocityDirectionY = JumpVelocity;
        Debug.Log("Player jump.");
    }
}