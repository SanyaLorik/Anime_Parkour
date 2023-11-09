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
        if (YandexGame.EnvironmentData.isDesktop == true)
        {
            _movement.DisactivateSelf();
            _input = new();

            return;
        }

        _eventTrigger = _movement.gameObject.AddComponent<EventTrigger>();

        _entry = new();
        _entry.eventID = EventTriggerType.PointerDown;
    }

    public void Enable()
    {
        if (YandexGame.EnvironmentData.isDesktop == true)
        {
            _input.Enable();
            _input.Player.Jump.started += OnPassByKeyboard;
            return;
        }

        _entry.callback.AddListener(OnTouchByPhone);
        _eventTrigger.triggers.Add(_entry);
    }


    public void Disable()
    {
        if (YandexGame.EnvironmentData.isDesktop == true)
        {
            _input.Disable();
            _input.Player.Jump.started -= OnPassByKeyboard;
            return;
        }

        _entry.callback.RemoveListener(OnTouchByPhone);
        _eventTrigger.triggers.Add(_entry);
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