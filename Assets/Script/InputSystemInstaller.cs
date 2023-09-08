using UnityEngine;
using Zenject;

public class InputSystemInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        Container
            .Bind<PlayerInputSystem>()
            .FromInstance(new());
        
        Debug.Log("PlayerInputSystem is installed.");
    }
}