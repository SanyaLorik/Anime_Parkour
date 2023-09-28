using DG.Tweening;
using UnityEngine;

public class UiScreenFader : MonoBehaviour
{
    [SerializeField] private GameObject _uiGameplay;
    [SerializeField] private CanvasGroup _canvasGroup;
    [SerializeField] private float _duration;
    [SerializeField] private Ease _ease;

    public void Unfade()
    {
        _canvasGroup.interactable = false;
        _uiGameplay.ActivateSelf();

        _canvasGroup
            .DOFade(0f, _duration)
            .SetEase(_ease);
    }
}
