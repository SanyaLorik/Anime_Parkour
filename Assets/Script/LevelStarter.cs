using DG.Tweening;
using UnityEngine;
using UnityEngine.Events;

public class LevelStarter : MonoBehaviour
{
    [SerializeField] private UiScreenFader _screenFader;
    [SerializeField] private PlayerTimer _playerTimer;

    [SerializeField] private UnityEvent OnStarted;

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
