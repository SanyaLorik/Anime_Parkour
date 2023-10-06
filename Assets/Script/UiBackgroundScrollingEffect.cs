using UnityEngine;
using UnityEngine.UI;

public class UiBackgroundScrollingEffect : MonoBehaviour 
{
    [SerializeField] private RawImage _rawImage;
    [SerializeField] private float _x;
    [SerializeField] private float _y;

    private void Update()
    {
        _rawImage.uvRect = new(_rawImage.uvRect.position + new Vector2(_x, _y) * Time.deltaTime, _rawImage.uvRect.size);
    }
}