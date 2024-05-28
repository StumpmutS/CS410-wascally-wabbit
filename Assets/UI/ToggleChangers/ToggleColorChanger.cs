using UnityEngine;
using UnityEngine.UI;

public class ToggleColorChanger : ToggleChanger
{
    [SerializeField] private Image targetImage;
    [SerializeField] private Color onColor, offColor;

    protected override void ChangeValue(bool value)
    {
        targetImage.color = value ? onColor : offColor;
    }
}