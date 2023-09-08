using UnityEngine;
using Zenject;

[RequireComponent(typeof(Collider))]
[RequireComponent(typeof(Rigidbody))]
public class KeyReceiver : MonoBehaviour
{
    [SerializeField] private InteractiveObject _interactiveObject;
    [SerializeField] private int _keyCount;

    private UiMessage _uiMessage;
    private bool _wasActivated = false;

    [Inject]
    private void Construct(UiMessage uiMessage)
    {
        _uiMessage = uiMessage;
    }
    
    private void OnTriggerEnter(Collider other)
    {
        if (_wasActivated == true)
            return;

        other.ReciveComponent<KeyCounter>()
            .IsCorrect(keyCounter => keyCounter.CanTake(_keyCount) == true, _uiMessage.AlertNotEnoughKeys)
            .Correct(keyCounter => keyCounter.Reduce(_keyCount))
            .CorrectWithoutArguments(Hide, _interactiveObject.Interact)
            .SetFlagTrue(ref _wasActivated);
    }

    private void Hide()
    {
        
    }
}