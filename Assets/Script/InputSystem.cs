using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using YG;
using static UnityEngine.EventSystems.EventTrigger;

[Serializable]
public class InputSystem
{
    [Header("Phone")]
    [SerializeField] private Image _movement;

    public event Action OnJumpStarted;

    private PlayerInputSystem _input;
    private EventTrigger _eventTrigger;
    private Entry _entry;

    public void Init()
    {
        _input = new();

        _eventTrigger = _movement.gameObject.AddComponent<EventTrigger>();

        _entry = new();
        _entry.eventID = EventTriggerType.PointerDown;
    }

    public void Enable()
    {
        _input.Enable();
        _entry.callback.AddListener(OnTouchByPhone);
        _eventTrigger.triggers.Add(_entry);

        _input.Player.Jump.started += OnPassByKeyboard;
    }


    public void Disable()
    {
        _input.Disable();
        _entry.callback.RemoveListener(OnTouchByPhone);
        _eventTrigger.triggers.Add(_entry);

        _input.Player.Jump.started -= OnPassByKeyboard;
    }

    private void OnTouchByPhone(BaseEventData eventData)
    {
        OnJumpStarted?.Invoke();
    }
    
    private void OnPassByKeyboard(InputAction.CallbackContext context)
    {
        OnJumpStarted?.Invoke();
    }
}