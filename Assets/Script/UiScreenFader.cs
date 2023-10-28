using DG.Tweening;
using DG.Tweening.Core;
using UnityEngine;

public class UiScreenFader : MonoBehaviour
{
    [SerializeField] private GameObject _uiMenu;
    [SerializeField] private GameObject _uiGameplay;
    [SerializeField] private CanvasGroup _canvasGroup;
    [SerializeField] private float _duration;
    [SerializeField] private Ease _ease;

    public void Fade()
    {
        _canvasGroup.interactable = true;
        _uiGameplay.DisactivateSelf();
        _uiMenu.ActivateSelf();

        _canvasGroup
            .DOFade(1f, _duration)
            .SetEase(_ease);
    }

    public TweenerCore<float, float, DG.Tweening.Plugins.Options.FloatOptions> Unfade()
    {
        _canvasGroup.interactable = false;
        _uiGameplay.ActivateSelf();

        return _canvasGroup
            .DOFade(0f, _duration)
            .SetEase(_ease);
    }
}
