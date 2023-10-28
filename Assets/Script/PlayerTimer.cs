using Cysharp.Threading.Tasks;
using System;
using TMPro;
using UnityEngine;

public class PlayerTimer : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _text;

    private int _counter = 0;
    private bool _isPaused = false;

    public void StartTimer()
    {
        if (_isPaused == false)
            StartCount().Forget();

        _isPaused = false;
    }

    public void Continue()
    {
        _isPaused = false;
    }

    public void Stop()
    {
        _isPaused = true;
    }

    public void ResetTimer()
    {
        _counter = 0;
        UpdateText();
    }

    public void Restart()
    {
        ResetTimer();
        _isPaused = false;
    }

    private async UniTaskVoid StartCount()
    {
        while (destroyCancellationToken.IsCancellationRequested == false)
        {
            await UniTask.Delay(1000, cancellationToken: destroyCancellationToken);
            await UniTask.WaitUntil(() => _isPaused == false, cancellationToken: destroyCancellationToken);

            _counter++;
            UpdateText();
        }
    }

    private void UpdateText()
    {
        _text.text = _counter.ToString();
    }
}