using DG.Tweening;
using UnityEngine;
using Zenject;

public class LevelPause : MonoBehaviour
{
    [SerializeField] private PlayerMovement _movement;
    [SerializeField] private PlayerAnimator _animator;
    [SerializeField] private PlayerTimer _timer;
    [SerializeField] private GroundGenerator _generator;

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
        _movement.Stop();
        _animator.Freeze();
        _input.Disable();
        _timer.Stop();
    }

    public void Continue()
    {
        _movement.Play();
        _animator.Unfreeze();
        _input.Enable();
        _timer.Continue();
    }    

    public void Restart()
    {
        _returner.Return(_movement);
        _animator.Unfreeze();
        _movement.Play();
        _input.Enable();
        _timer.Restart();
        _generator.DestroyAllGrounds();
        _generator.GenerateFirts();
    }
}
