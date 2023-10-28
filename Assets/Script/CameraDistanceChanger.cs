using Cinemachine;
using Cysharp.Threading.Tasks;
using UnityEngine;

public class CameraDistanceChanger : MonoBehaviour
{
    [SerializeField] private PlayerMovement _movement;
    [SerializeField] private CinemachineVirtualCamera _camera;
    [SerializeField] private float _velocityDirectionY;
    [SerializeField] private float _distance;

    private CinemachineFramingTransposer _framingTransposer;
    private float _initialDistance;
    
    private void Start()
    {
        _framingTransposer = _camera.GetCinemachineComponent(CinemachineCore.Stage.Body) as CinemachineFramingTransposer;
        _initialDistance = _framingTransposer!.m_CameraDistance;

        TrackDistance().Forget();
    }

    public void ResetDistance()
    {
        _framingTransposer.m_CameraDistance = _initialDistance;
    }

    private async UniTaskVoid TrackDistance()
    {
        do
        {
            await UniTask.WaitUntil(() => _movement.VelocityDirectionY >= _velocityDirectionY);
            _framingTransposer.m_CameraDistance = _distance;
            
            await UniTask.WaitUntil(() => _movement.CanJump == true);
            _framingTransposer.m_CameraDistance = _initialDistance;
        } 
        while (destroyCancellationToken.IsCancellationRequested == false);
    }
}