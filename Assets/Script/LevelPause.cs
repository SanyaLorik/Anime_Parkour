﻿using DG.Tweening;
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

    private InputSystem _input;
    private StartReturner _returner;

    [SerializeField] private UnityEvent OnPaused;
    [SerializeField] private UnityEvent OnContinued;
    [SerializeField] private UnityEvent OnRestarted;

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
        _input.Disable();
        _timer.Stop();
        _distanceTracker.PauseCountScore();
    }

    public void Continue()
    {
        OnContinued?.Invoke();

        _movement.Play();
        _animator.Unfreeze();
        _input.Enable();
        _timer.Continue();
        _distanceTracker.ContinueCountScore();
    }    

    public void Restart()
    {
        OnRestarted?.Invoke();

        _returner.Return(_movement);
        _animator.Unfreeze();
        _movement.Play();
        _input.Enable();
        _timer.Restart();
        _generator.DestroyAllGrounds();
        _generator.GenerateFirts();
        _distanceTracker.ResetScoreCounter();
        _distanceTracker.StartCountScore();
        _inputSystemViewer.StartAnimation();
    }
}
