using UnityEngine;
using Zenject;

public class StartReturnerInstaller : MonoInstaller
{
    [SerializeField] private StartReturner _returner;
    
    public override void InstallBindings()
    {
        Container
            .Bind<StartReturner>()
            .FromInstance(_returner)
            .AsCached();
        
        Debug.Log("StartReturner is installed.");
    }
}