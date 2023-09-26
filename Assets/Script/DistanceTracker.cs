using System;
using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class DistanceTracker : MonoBehaviour
{
    [SerializeField] private Transform _player;
    
    [Header("Ui")] 
    [SerializeField] private Image _progress;

    [Header("Point")]
    [SerializeField] private Transform _initalPoint;
    [SerializeField] private Transform _finalPoint;

    [Header("Settings")] 
    [SerializeField] private float _delayUpdating;
    [SerializeField][Range(0f, 1f)] private float _errorRate;
    [SerializeField][Range(0f, 1f)] private float _minimumRate;

    private float _lastRotation;

    private void Start()
    {
        _lastRotation = _minimumRate;
        TrackProgress().Forget();
    }
    private async UniTaskVoid TrackProgress()
    {
        float totalDistance = Vector3.Distance(_initalPoint.position, _finalPoint.position);
        
        do
        {
            await UniTask.Delay(_delayUpdating.ToDelayMillisecond());
            
            var remainingDistance = Vector3.Distance(_player.position, _finalPoint.position);
            float ration = 1 - (remainingDistance / totalDistance);
            float fillAmount = MathF.Max(_lastRotation, ration);
            _lastRotation = fillAmount;
            
            _progress.fillAmount = ration >= 1 - _errorRate ? 1f : fillAmount;
        } 
        while (destroyCancellationToken.IsCancellationRequested == false);
    }
}