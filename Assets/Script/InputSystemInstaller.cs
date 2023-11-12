using UnityEngine;
using Zenject;

public class InputSystemInstaller : MonoInstaller
{
    [SerializeField] private InputSystem _inputSystem;

    public override void InstallBindings()
    {
        _inputSystem.Init().Forget();

        Container
            .Bind<InputSystem>()
            .FromInstance(_inputSystem);
        
        Debug.Log("PlayerInputSystem is installed.");
    }
}