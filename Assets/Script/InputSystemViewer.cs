using Cysharp.Threading.Tasks;
using DG.Tweening;
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

        animation.Container.transform.localScale = Vector3.zero;
        await animation.Container.transform.DOScale(Vector3.one, animation.Duration).SetEase(animation.Ease).AsyncWaitForCompletion().AsUniTask();

        for (int i = 0; i < animation.Count; i++)
        {
            animation.Normal.DisactivateSelf();
            animation.Pressed.ActivateSelf();

            await UniTask.Delay(animation.Delay.ToDelayMillisecond(), cancellationToken: destroyCancellationToken);

            animation.Normal.ActivateSelf();
            animation.Pressed.DisactivateSelf();

            await UniTask.Delay(animation.Delay.ToDelayMillisecond(), cancellationToken: destroyCancellationToken);
        }

        await animation.Container.transform.DOScale(Vector3.zero, animation.Duration).SetEase(animation.Ease).AsyncWaitForCompletion().AsUniTask();

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


    [field: Header("Incoming/Outcoming")]
    [field: SerializeField] public Ease Ease { get; private set; }

    [field: SerializeField] public float Duration { get; private set; }
}