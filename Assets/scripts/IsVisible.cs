using UnityEngine;

public class IsVisible : MonoBehaviour
{
    private Renderer[] renderers;   // Array to hold all Renderer components (object + children)

    void Start()
    {
        // Get all renderer components in this object and its children
        renderers = GetComponentsInChildren<Renderer>();

        // Initially, set all renderers to be invisible
        SetVisibility(false);
    }

    // Method to make the object and its children visible
    public void ShowObject()
    {
        SetVisibility(true);  // Enable visibility for all renderers
    }

    // Method to make the object and its children invisible
    public void HideObject()
    {
        SetVisibility(false);  // Disable visibility for all renderers
    }

    // Helper method to set the visibility for all renderers
    private void SetVisibility(bool isVisible)
    {
        foreach (Renderer renderer in renderers)
        {
            if (renderer != null)
            {
                renderer.enabled = isVisible;  // Set each renderer's visibility
            }
        }
    }
}
