using UnityEngine;

public class ActivityEnabler : MonoBehaviour
{
    [SerializeField] private GameObject[] _activateables;
    [SerializeField] private GameObject[] _disactivateables;

    public void Activate()
    {
        _activateables.ActivateArraySelf();
    }

    public void Disctivate()
    {
        _disactivateables.DisctivateArraySelf();
    }
}
