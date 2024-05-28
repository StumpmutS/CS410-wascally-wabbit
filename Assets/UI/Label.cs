using TMPro;
using UnityEngine;

public class Label : MonoBehaviour
{
    [SerializeField] private TMP_Text text;

    public void SetLabel(string value)
    {
        if (text == null)
        {
            Debug.LogWarning("No text component referenced");
            return;
        }
        
        text.text = value;
    }
}
