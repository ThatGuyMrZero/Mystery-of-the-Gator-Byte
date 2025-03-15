using UnityEngine;

public class CloseButtonHandler : MonoBehaviour
{
    public TextBoxManager textBoxManager;

    void OnMouseDown()
    {
        if (textBoxManager != null)
        {
            textBoxManager.HideAllTextBoxes();
        }
    }
}
