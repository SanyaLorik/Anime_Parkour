using UnityEngine;

public class LevelStarter : MonoBehaviour
{
    [SerializeField] private UiScreenFader _screenFader;
    
    public void StartLevel()
    {
        _screenFader.Unfade();
    }
}
