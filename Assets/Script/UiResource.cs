using TMPro;
using UnityEngine;
using UnityEngine.Serialization;

public class UiResource : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _keyText;

    public void UpdateKeyText(int coin)
    {
        _keyText.text = coin.ToString();
    }
}