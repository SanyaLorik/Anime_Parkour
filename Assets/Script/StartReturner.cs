using System;
using UnityEngine;

[Serializable]
public class StartReturner
{
    [SerializeField] private Transform _initialPoint;

    public event Action OnReturned;

    public void Return(PlayerMovement playerMovement)
    {
        playerMovement.transform.position = _initialPoint.position;
        
        playerMovement.DisactivateSelf();
        playerMovement.ActivateSelf();

        OnReturned?.Invoke();

        Debug.Log("Player is returned to the start.");
    }
}