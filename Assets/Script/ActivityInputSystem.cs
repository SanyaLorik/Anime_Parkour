using UnityEngine;
using Zenject;

public class ActivityInputSystem : MonoBehaviour
{
    private InputSystem _input;

    [Inject]
    private void Construct(InputSystem input)
    {
        _input = input;
    }

    public void Activate()
    {
        _input.Enable();
    }
}
