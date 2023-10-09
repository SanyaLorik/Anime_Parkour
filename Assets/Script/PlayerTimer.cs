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
        StartCount().Forget();
    }

    public void Continue()
    {
        _isPaused = false;
    }

    public void Stop()
    {
        _isPaused = true;
    }

    public void Restart()
    {
        _counter = 0;
        UpdateText();

        _isPaused = false;
    }

    private async UniTaskVoid StartCount()
    {
        while (destroyCancellationToken.IsCancellationRequested == false)
        {
            await UniTask.Delay(1000, cancellationToken: destroyCancellationToken);
            await UniTask.WaitUntil(() => _isPaused == false, cancellationToken: destroyCancellationToken);

            UpdateText();
            _counter++;
        }
    }

    private void UpdateText()
    {
        _text.text = _counter.ToString();
    }
}