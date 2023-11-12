using System;
using UnityEngine;
using Zenject;

public class UiInstaller : MonoInstaller
{
    [SerializeField] private UiResource _resource;
    [SerializeField] private UiMessage _uiMessage;
    [SerializeField] private UiMenu _menu;
    
    public override void InstallBindings()
    {
        BindResource();
        BindMessage();
        BindUiMenu();
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

    private void BindUiMenu()
    {
        Container
            .Bind<UiMenu>()
            .FromInstance(_menu);

        Debug.Log("UiMenu is installed.");
    }
}