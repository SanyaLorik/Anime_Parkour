using System;
using UnityEngine;
using UnityEngine.UI;

public class UiPause : MonoBehaviour
{
    [SerializeField] private LevelPause _levelPause;

    [Header("Ui")]
    [SerializeField] private GameObject _panel;
    [SerializeField] private Button _paused;
    [SerializeField] private Button _continued;
    [SerializeField] private Button _restarted;

    private void OnEnable()
    {
        _paused.onClick.AddListener(OnPause);
        _continued.onClick.AddListener(OnContinue);
        _restarted.onClick.AddListener(OnRestart);
    }

    private void OnDisable()
    {
        _paused.onClick.RemoveListener(OnPause);
        _continued.onClick.RemoveListener(OnContinue);
        _restarted.onClick.RemoveListener(OnRestart);
    }

    private void OnPause()
    {
        _panel.ActivateSelf();
        _levelPause.Pause();
    }

    private void OnContinue()
    {
        _panel.DisactivateSelf();
        _levelPause.Continue();
    }

    private void OnRestart()
    {
        _panel.DisactivateSelf();
        _levelPause.Restart();
    }

}
