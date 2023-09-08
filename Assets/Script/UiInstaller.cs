using UnityEngine;
using Zenject;

public class UiInstaller : MonoInstaller
{
    [SerializeField] private UiResource _resource;
    [SerializeField] private UiMessage _uiMessage;
    
    public override void InstallBindings()
    {
        BindResource();
        BindMessage();
    }

    private void BindResource()
    {
        Container
            .Bind<UiResource>()
            .FromInstance(_resource);

        Debug.Log("UiResource is installed.");
    }
    
    private void BindMessage()
    {
        Container
            .Bind<UiMessage>()
            .FromInstance(_uiMessage);

        Debug.Log("UiMessage is installed.");
    }
}