using Cysharp.Threading.Tasks;
using UnityEngine;

public class FollowerMainGround : MonoBehaviour
{
    [SerializeField] private PlayerMovement _movement;
    [SerializeField] private Transform _player;
    [SerializeField] private Transform _source;
    [SerializeField] private Vector3 _offset;

    private void Start()
    {
        FollowForPlayer().Forget();
    }

    private async UniTaskVoid FollowForPlayer()
    {
        int delay = 256;

        do
        {
            await UniTask.Delay(delay, cancellationToken: destroyCancellationToken);
            _source.position = _player.position + _offset;
            await UniTask.WaitUntil(() => _movement.CanJump == true);
        } 
        while (destroyCancellationToken.IsCancellationRequested == false);
    }
}