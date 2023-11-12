using UnityEngine;
using UnityEngine.Events;
using Zenject;

public class LevelPause : MonoBehaviour
{
    [SerializeField] private PlayerMovement _movement;
    [SerializeField] private PlayerAnimator _animator;
    [SerializeField] private PlayerTimer _timer;
    [SerializeField] private GroundGenerator _generator;
    [SerializeField] private DistanceTracker _distanceTracker;
    [SerializeField] private InputSystemViewer _inputSystemViewer;

    [SerializeField] private UnityEvent OnPaused;
    [SerializeField] private UnityEvent OnContinued;
    [SerializeField] private UnityEvent OnRestarted;

    private InputSystem _input;
    private StartReturner _returner;

    [Inject]
    private void Construct(InputSystem input, StartReturner returner)
    {
        _input = input;
        _returner = returner;
    }

    public void Pause()
    {   
        OnPaused?.Invoke();

        _movement.Stop();
        _animator.Freeze();
        _input.Disable().Forget();
        _timer.Stop();
        _distanceTracker.PauseCountScore();
    }

    public void Continue()
    {
        OnContinued?.Invoke();

        _movement.Play();
        _animator.Unfreeze();
        _input.Enable().Forget();
        _timer.Continue();
        _distanceTracker.ContinueCountScore();
    }    

    public void Restart()
    {
        OnRestarted?.Invoke();

        _returner.Return(_movement);
        _animator.Unfreeze();
        _movement.ResetVelocityDirectionY();
        _movement.Play();
        _input.Enable().Forget();
        _timer.Restart();
        _generator.DestroyAllGrounds();
        _generator.GenerateFirts();
        _distanceTracker.ResetScoreCounter();
        _distanceTracker.StartCountScore();
        _inputSystemViewer.StartAnimation();
    }
}
