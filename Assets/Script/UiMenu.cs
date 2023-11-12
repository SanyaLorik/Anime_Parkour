using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using YG;

public class UiMenu : MonoBehaviour
{
    [Header("Start game")]
    [SerializeField] private Button _started;
    [SerializeField] private LevelStarter _levelStarter;

    [Header("Score")]
    [SerializeField] private TextMeshProUGUI _bestScore;

    private void OnEnable()
    {
        _started.onClick.AddListener(_levelStarter.StartLevel);
        YandexGame.GetDataEvent += OnLoadData;
    }

    private void OnDisable()
    {
        _started.onClick.RemoveListener(_levelStarter.StartLevel);
        YandexGame.GetDataEvent -= OnLoadData;
    }

    private void OnLoadData()
    {
        UpdateBestScore(YandexGame.savesData.bestScore);
    }

    public void UpdateBestScore(long bestScore)
    {
        _bestScore.text = bestScore.ToString();
    }
}
