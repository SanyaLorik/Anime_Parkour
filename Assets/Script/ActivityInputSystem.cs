using UnityEngine;
using Zenject;

public class ActivityInputSystem : MonoBehaviour
{
    private PlayerInputSystem _input;

    [Inject]
    private void Construct(PlayerInputSystem input)
    {
        _input = input;
    }

    public void Activate()
    {
        _input.Enable();
    }
}
