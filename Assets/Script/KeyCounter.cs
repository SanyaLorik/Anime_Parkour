using UnityEngine;
using Zenject;

public class KeyCounter : MonoBehaviour
{
    private PlayerCollision _playerCollision;
    private UiResource _uiResource;
    
    private int _count = 0;

    [Inject]
    private void Construct(PlayerCollision playerCollision, UiResource uiResource)
    {
        _playerCollision = playerCollision;
        _uiResource = uiResource;
    }
    
    private void OnEnable()
    {
        _playerCollision.OnTriggerEncountered += OnTriggerCount;
    }

    private void OnDisable()
    {
        _playerCollision.OnTriggerEncountered -= OnTriggerCount;
    }

    public bool CanTake(int count)
    {
        return _count >= count;
    }

    public void Reduce(int count)
    {
        UpdateKey(-count);
    }

    private void OnTriggerCount(Transform obj)
    {
        obj.ReciveComponent<Key>().Correct(coin =>
        {
            Add();
            coin.PickUp();
            
            Debug.Log("Coin is picked up.");
        });
    }

    private void Add()
    {
        UpdateKey(1);
    }
    
    private void UpdateKey(int count)
    {
        _count += count;
        _uiResource.UpdateKeyText(_count);
    }
}