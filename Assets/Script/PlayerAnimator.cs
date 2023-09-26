using Cysharp.Threading.Tasks;
using UnityEngine;

public class PlayerAnimator : MonoBehaviour
{
    [SerializeField] private Animator _animator;
    [SerializeField] private CharacterController _character;

    private readonly int _runningHash = Animator.StringToHash("Running");

    private void Start()
    {
        AnimateRunning().Forget();
    }

    private async UniTaskVoid AnimateRunning()
    {
        do
        {
            _animator.SetFloat(_runningHash, _character.velocity.magnitude);
            await UniTask.Yield();
        }
        while (destroyCancellationToken.IsCancellationRequested == false);
    }
}