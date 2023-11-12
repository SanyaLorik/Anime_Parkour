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
    [SerializeField] private DistanceTracker _distanceTracker;

    [SerializeField] private UnityEvent OnExited;

    private InputSystem _input;
    private StartReturner _returner;

    [Inject]
    private void Construct(InputSystem input, StartReturner returner)
    {
        _input = input;
        _returner = returner;
    }

    public void Exit()
    {
        _returner.Return(_movement);
        _movement.ResetVelocityDirectionY();
        _movement.Stop();
        _generator.DestroyAllGrounds();
        _input.Disable().Forget();
        _timer.Stop();
        _timer.ResetTimer();
        _screenFader.Fade();
        _cameraDistanceChanger.ResetDistance();
        _distanceTracker.ResetScoreCounter();

        OnExited?.Invoke();
    }
}