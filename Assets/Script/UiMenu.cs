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

    [Header("Rate Game")]
    [SerializeField] private Button _rateGame;

    private void OnEnable()
    {
        _started.onClick.AddListener(_levelStarter.StartLevel);
        _rateGame.onClick.AddListener(OnRateGame);

        YandexGame.GetDataEvent += OnLoadData;
    }

    private void OnDisable()
    {
        _started.onClick.RemoveListener(_levelStarter.StartLevel);
        _rateGame.onClick.RemoveListener(OnRateGame);

        YandexGame.GetDataEvent -= OnLoadData;
    }

    private void OnLoadData()
    {
        if (YandexGame.auth == false)
            _rateGame.DisactivateSelf();

        UpdateBestScore(YandexGame.savesData.bestScore);
    }

    private void OnRateGame()
    {
        throw new NotImplementedException();
    }

    public void UpdateBestScore(long bestScore)
    {
        _bestScore.text = bestScore.ToString();
    }
}
