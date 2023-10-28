using UnityEngine;
using UnityEngine.Events;
using Zenject;

public class LevelExit : MonoBehaviour
{
    [SerializeField] private PlayerMovement _movement;
    [SerializeField] private PlayerTimer _timer;
    [SerializeField] private GroundGenerator _generator;
    [SerializeField] private UiScreenFader _screenFader;
    [SerializeField] private CameraDistanceChanger _cameraDistanceChanger;

    [SerializeField] private UnityEvent OnExited;

    private PlayerInputSystem _input;
    private StartReturner _returner;

    [Inject]
    private void Construct(PlayerInputSystem input, StartReturner returner)
    {
        _input = input;
        _returner = returner;
    }

    public void Exit()
    {
        _returner.Return(_movement);
        _movement.Stop();
        _generator.DestroyAllGrounds();
        _input.Disable();
        _timer.Stop();
        _timer.ResetTimer();
        _screenFader.Fade();
        _cameraDistanceChanger.ResetDistance();
        OnExited?.Invoke();
    }
}