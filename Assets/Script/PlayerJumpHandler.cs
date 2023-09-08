using UnityEngine;
using UnityEngine.InputSystem;
using Zenject;

[RequireComponent(typeof(CharacterController))]
[RequireComponent(typeof(PlayerMovement))]
public class PlayerJumpHandler : MonoBehaviour
{
    [Header("Stats")]
    [SerializeField] private float _jumpTime;
    [SerializeField] private float _jumpHeight;

    private PlayerMovement _movement;
    private CharacterController _controller;
    private PlayerInputSystem _inputSystem;
    
    [Inject]
    private void Construct(PlayerInputSystem inputSystem)
    {
        _inputSystem = inputSystem;
    }
    
    private void Awake()
    {
        _movement = GetComponent<PlayerMovement>();
        _controller = GetComponent<CharacterController>();
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

    public void Jump(float jumpTime, float jumpHeight)
    {
        if (_controller.isGrounded == false)
            return;
        
        _movement.VelocityDirectionY = CalculateJumpVelocity(jumpTime, jumpHeight);
        
        Debug.Log("Player jump.");
    }
    
    private void OnJump(InputAction.CallbackContext _)
    {
        Jump(_jumpTime, _jumpHeight);
    }
    
    private float CalculateJumpVelocity(float jumpTime, float jumpHeight)
    {
        float maxHeightTime = jumpTime / 2;
        _movement.GravityForce = (2 * jumpHeight) / Mathf.Pow(maxHeightTime, 2);
        return (2 * jumpHeight) / maxHeightTime;
    }
}