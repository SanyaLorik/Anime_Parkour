using UnityEngine;
using Zenject;

public class AudioInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        Container
            .Bind<AudioSettings>()
            .FromInstance(new())
            .AsCached();

        Debug.Log("AudioSettings is installed.");
    }
}
