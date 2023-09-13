using System;
using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

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
    
    private void Start()
    {
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
            _progress.fillAmount = ration >= 1 - _errorRate ? 1f : ration;
        } 
        while (destroyCancellationToken.IsCancellationRequested == false);
    }
}