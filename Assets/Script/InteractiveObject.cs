using UnityEngine;

public class InteractiveObject : MonoBehaviour
{
    [SerializeField] private SoleAnimation _soleAnimation;
    
    public void Interact()
    {
        _soleAnimation.Animate();
    }
}