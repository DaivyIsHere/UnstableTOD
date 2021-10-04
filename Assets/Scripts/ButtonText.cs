using UnityEngine;
using UnityEngine.UI;

public class ButtonText : MonoBehaviour
{
    [SerializeField] private Text _text;
    [SerializeField] private Color32 _originalColor;
    [SerializeField] private Color32 _hoverColor;

    public void PointerEnter() => _text.color = _hoverColor;

    public void PointerExit() => _text.color = _originalColor;
}
