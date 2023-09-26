using UnityEngine;

public class DestroyedTimer : MonoBehaviour
{
    [SerializeField] private float _timer;

    private void Awake()
    {
        Destroy(gameObject, _timer);
    }
}