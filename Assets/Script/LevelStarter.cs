using DG.Tweening;
using UnityEngine;
using UnityEngine.Events;

public class LevelStarter : MonoBehaviour
{
    [SerializeField] private PlayerMovement _playerMovement;
    [SerializeField] private UiScreenFader _screenFader;
    [SerializeField] private PlayerTimer _playerTimer;

    [SerializeField] private UnityEvent OnStarted;
    [SerializeField] private UnityEvent OnGameLoaded;

    private void Start()
    {
        OnGameLoaded?.Invoke();
    }

    public void StartLevel()
    {
        _screenFader
            .Unfade()
            .OnComplete(() =>
            {
                OnStarted?.Invoke();
                _playerTimer.StartTimer();
            });
    }
}
