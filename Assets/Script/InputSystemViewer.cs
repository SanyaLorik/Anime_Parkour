using Cysharp.Threading.Tasks;
using System;
using UnityEngine;
using YG;
using Zenject;

public class InputSystemViewer : MonoBehaviour
{
    [SerializeField] private AnimationInputSystemDevice _desktop;
    [SerializeField] private AnimationInputSystemDevice _mobile;

    private StartReturner _returner;

    [Inject]
    private void Construct(StartReturner returner)
    {
        _returner = returner;
    }

    private void OnEnable()
    {
        _returner.OnReturned += OnStartAnimation;
    }

    private void OnDisable()
    {
        _returner.OnReturned -= OnStartAnimation;
    }

    public void StartAnimation()
    {
        OnStartAnimation();
    }

    private bool IsDesktop => YandexGame.EnvironmentData.isDesktop;

    private void OnStartAnimation()
    {
        _mobile.Container.ActivateSelf();
        Animate(_mobile).Forget();
        /*
        if (IsDesktop == true)
            Animate(_desktop).Forget();
        else
            Animate(_mobile).Forget();
        */
        //ActiveContainerControl(IsDesktop);
    }

    private async UniTaskVoid Animate(AnimationInputSystemDevice animation)
    {
        animation.Normal.ActivateSelf();
        animation.Pressed.DisactivateSelf();

        for (int i = 0; i < animation.Count; i++)
        {
            animation.Normal.DisactivateSelf();
            animation.Pressed.ActivateSelf();

            await UniTask.Delay(animation.Delay.ToDelayMillisecond(), cancellationToken: destroyCancellationToken);

            animation.Normal.ActivateSelf();
            animation.Pressed.DisactivateSelf();

            await UniTask.Delay(animation.Delay.ToDelayMillisecond(), cancellationToken: destroyCancellationToken);
        }

        animation.Container.DisactivateSelf();
    }

    private void ActiveContainerControl(bool isDesktop)
    {
        _desktop.Container.SetActive(isDesktop == true);
        _mobile.Container.SetActive(isDesktop == false);
    }
}

[Serializable]
public struct AnimationInputSystemDevice
{
    [field: SerializeField] public GameObject Container { get; private set; }

    [field: SerializeField] public GameObject Normal { get; private set; }  

    [field: SerializeField] public GameObject Pressed { get; private set; }

    [field: SerializeField] public int Count { get; private set; }

    [field: SerializeField] public float Delay { get; private set; }
}