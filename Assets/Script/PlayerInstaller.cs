using System;
using UnityEngine;
using Zenject;

public class PlayerInstaller : MonoInstaller
{
    [SerializeField] private PlayerCollision _playerCollision;
    
    public override void InstallBindings()
    {
        Container
            .Bind<PlayerCollision>()
            .FromInstance(_playerCollision);
        
        Debug.Log("PlayerCollision is installed.");
    }
}
