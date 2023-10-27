using System;
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

    public event Action OnJumped;
    
    private PlayerMovement _movement;
    private PlayerInputSystem _inputSystem;
    
    [Inject]
    private void Construct(PlayerInputSystem inputSystem)
    {
        _inputSystem = inputSystem;
    }
    
    private void Awake()
    {
        _movement = GetComponent<PlayerMovement>();
    }

    private void OnEnable()
    {
        _inputSystem.Player.Jump.started += OnJump;
    }

    private void OnDisable()
    {
        _inputSystem.Player.Jump.started -= OnJump;
    }

    public void Jump(float jumpTime, float jumpHeight)
    {
        if (_movement.CanJump == false)
            return;
        
        _movement.VelocityDirectionY = CalculateJumpVelocity(jumpTime, jumpHeight);
        OnJumped?.Invoke();
        
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
