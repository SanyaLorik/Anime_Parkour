using UnityEngine;

public class LevelStarter : MonoBehaviour
{
    [SerializeField] private UiScreenFader _screenFader;
    [SerializeField] private PlayerTimer _playerTimer;
    [SerializeField] private ActivityEnabler _activityEnabler;

    public void StartLevel()
    {
        _screenFader.Unfade();
        _playerTimer.StartTimer();
        _activityEnabler.Disctivate();
    }
}
