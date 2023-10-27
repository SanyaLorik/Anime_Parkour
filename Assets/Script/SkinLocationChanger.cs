using UnityEngine;

public class SkinLocationChanger : MonoBehaviour
{
    [SerializeField] private LocationSkinButton[] _buttons;

    private void OnEnable()
    {
        foreach (var button in _buttons)
            button.Button.onClick.AddListener(() => RenderSettings.skybox = button.SkinLocation);
    }

    private void OnDisable()
    {
        foreach (var button in _buttons)
            button.Button.onClick.RemoveAllListeners();
    }
}
