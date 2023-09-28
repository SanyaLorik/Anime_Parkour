using UnityEngine;
using UnityEngine.UI;

public class UiMenu : MonoBehaviour
{
    [SerializeField] private Button _started;
    [SerializeField] private LevelStarter _levelStarter;

    private void OnEnable()
    {
        _started.onClick.AddListener(_levelStarter.StartLevel);
    }

    private void OnDisable()
    {
        _started.onClick.RemoveListener(_levelStarter.StartLevel);
    }
}