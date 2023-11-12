using Cysharp.Threading.Tasks;
using System;
using System.Threading;
using TMPro;
using UnityEngine;
using YG;
using Zenject;

public class DistanceTracker : MonoBehaviour
{
    [SerializeField] private Transform _player;
    
    [Header("Ui")] 
    [SerializeField] private UiDistanceTracker _ui;

    [Header("Point")]
    [SerializeField] private Transform _initalPoint;
    [SerializeField] private Transform _finalPoint;

    [Header("Settings")] 
    [SerializeField] private float _delay;
    [SerializeField] private int _addingScore;

    private UiMenu _menu;
    private StartReturner _startReturner;
    private long _currentScore = 0;
    private long _bestScore = 0;

    private CancellationTokenSource _tokenSource;
    private bool _isPaused = false;

    [Inject]
    private void Construct(StartReturner startReturner, UiMenu menu)
    {
        _startReturner = startReturner;
         _menu = menu;
    }

    private void OnEnable()
    {
        _startReturner.OnReturned += OnFixScore;
        YandexGame.GetDataEvent += OnLoadData;
    }

    private void OnDisable()
    {
        _startReturner.OnReturned -= OnFixScore;
        YandexGame.GetDataEvent -= OnLoadData;
    }

    private void OnDestroy()
    {
        _tokenSource?.Cancel();
        _tokenSource?.Dispose();
    }

    public void StartCountScore()
    {
        _isPaused = false;
        _tokenSource = new();
        CountCurrentScore(_tokenSource.Token).Forget();
    }

    public void PauseCountScore()
    {
        _isPaused = true;
    }

    public void ContinueCountScore()
    {
        _isPaused = false;
    }

    public void ResetScoreCounter()
    {
        _tokenSource?.Cancel();
        _currentScore = 0;
        _ui.ShowPopupBestScore(_currentScore);
    }

    private void OnFixScore()
    {
        if (_bestScore < _currentScore)
        {
            _ui.SetBestScore(_currentScore);
            _ui.ShowPopupBestScore(_currentScore);
            _bestScore = _currentScore;

            _menu.UpdateBestScore(_bestScore);

            YandexGame.savesData.bestScore = _bestScore;
            YandexGame.SaveProgress();
        }

        CustomDebug.Log("Score is fixed! Current score is ", _currentScore);
        _currentScore = 0;
    }

    private void OnLoadData()
    {
        _bestScore = YandexGame.savesData.bestScore;
        _ui.SetBestScore(_bestScore);
    }

    private async UniTaskVoid CountCurrentScore(CancellationToken token)
    {
        bool isAttainedBestScore = false;

        do
        {
            await UniTask.Delay(_delay.ToDelayMillisecond(), cancellationToken: token);
            await UniTask.WaitUntil(() => _isPaused == false, cancellationToken: token);

            _currentScore += _addingScore;
            _ui.SetCurrentScore(_currentScore);

            if (isAttainedBestScore == false)
            {
                if (_currentScore >= _bestScore)
                {
                    _ui.ShowPopupAttainedToBestScore();
                    isAttainedBestScore = true;
                }
            }
        } 
        while (token.IsCancellationRequested == false);
    }
}

[Serializable]
public struct UiDistanceTracker
{
    [SerializeField] private TextMeshProUGUI _currentScore;
    [SerializeField] private TextMeshProUGUI _bestScore;

    public void SetBestScore(long score)
    {
        _bestScore.text = score.ToString();
    }

    public void SetCurrentScore(long score)
    {
        _currentScore.text = score.ToString();
    }

    public void ShowPopupBestScore(long bestScore)
    {

    }

    public void ShowPopupAttainedToBestScore()
    {

    }
}