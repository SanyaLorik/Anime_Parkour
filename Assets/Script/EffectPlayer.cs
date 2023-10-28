using Cysharp.Threading.Tasks;
using UnityEngine;
using Zenject;

public class EffectPlayer : MonoBehaviour
{
    [SerializeField] private PlayerMovement _movement;
    [SerializeField] private PlayerJumpHandler _jumpHandler;

    [Header("Landing")] 
    [SerializeField] private Transform _landingPoint;
    [SerializeField] private ParticleSystem _groundEffectPrefab;
    [SerializeField] private float _velocityDirectionY;
    
    [Header("Jump")] 
    [SerializeField] private Transform _jumpPoint;
    [SerializeField] private ParticleSystem _jumpEffectPrefab;

    private PrefabPositionSpawner _spawner;

    [Inject]
    private void Construct(PrefabPositionSpawner spawner)
    {
        _spawner = spawner;
    }
    
    private void Start()
    {
        PlayLandingEffectAsync().Forget();
    }

    private void OnEnable()
    {
        _jumpHandler.OnJumped += OnPlayJumpEffect;
    }

    private void OnDisable()
    {
        _jumpHandler.OnJumped -= OnPlayJumpEffect;
    }

    private void OnPlayJumpEffect()
    {
        _spawner.Spawn(_jumpEffectPrefab, _jumpPoint.position).Play();
    }
    
    private async UniTaskVoid PlayLandingEffectAsync()
    {
        do
        {
            await UniTask.WaitUntil(() => _movement.CanJump == false, cancellationToken: destroyCancellationToken);
            await UniTask.WaitUntil(() => _velocityDirectionY >=_movement.VelocityDirectionY, cancellationToken: destroyCancellationToken);
            await UniTask.WaitUntil(() => _movement.CanJump == true, cancellationToken: destroyCancellationToken);

            _spawner.Spawn(_groundEffectPrefab, _landingPoint.position).Play();

        } 
        while (destroyCancellationToken.IsCancellationRequested == false);
    }
}

public class AudioPlayer : MonoBehaviour
{
    [SerializeField] private PlayerMovement _movement;
    [SerializeField] private PlayerJumpHandler _jumpHandler;

    [SerializeField] private AudioSource _running;
    [SerializeField] private AudioSource _jumping;

    private async UniTaskVoid PlaySoundAsync()
    {
        do
        {


        }
        while (destroyCancellationToken.IsCancellationRequested == false);
    }
}