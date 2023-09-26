using Cysharp.Threading.Tasks;
using TMPro;
using UnityEngine;

public class PlayerTimer : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _text;

    private bool _isPlaying = true;

    private void Start()
    {
        StartCount().Forget();
    }

    private async UniTaskVoid StartCount()
    {
        _isPlaying = true;

        int counter = 0;
        while (_isPlaying == true && destroyCancellationToken.IsCancellationRequested == false)
        {
            await UniTask.Delay(1000, cancellationToken: destroyCancellationToken);

            _text.text = counter.ToString();
            counter++;
        }
    }
}