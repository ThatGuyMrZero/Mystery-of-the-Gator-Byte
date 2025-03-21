using UnityEngine;

public class SpriteClickHandler : MonoBehaviour
{
    public TextBoxManager textBoxManager;
    public string textType; // Will store the type (e.g., "Char", "Boolean", "Array")

    void OnMouseDown()
    {
        if (textBoxManager != null)
        {
            textBoxManager.ShowTextBox(textType);
        }
    }
}
