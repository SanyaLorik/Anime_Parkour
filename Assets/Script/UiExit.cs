using UnityEngine;
using UnityEngine.UI;

public class UiExit : MonoBehaviour
{
    [SerializeField] private Button _button;
    [SerializeField] private LevelExit _level;

    private void OnEnable()
    {
        _button.onClick.AddListener(_level.Exit);
    }

    private void OnDisable()
    {
        _button.onClick.RemoveListener(_level.Exit);
    }
}