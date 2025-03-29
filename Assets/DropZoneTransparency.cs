using UnityEngine;
using UnityEngine.UI; // For UI Image

public class DropZoneTransparency : MonoBehaviour
{
    private Image imageComponent;
    private SpriteRenderer spriteRenderer;

    void Awake()
    {
        imageComponent = GetComponent<Image>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    public void MakeTransparent()
    {
        if (imageComponent != null)
        {
            Color c = imageComponent.color;
            c.a = 0f;
            imageComponent.color = c;
        }
        else if (spriteRenderer != null)
        {
            Color c = spriteRenderer.color;
            c.a = 0f;
            spriteRenderer.color = c;
        }
        else
        {
            Debug.LogWarning("No Image or SpriteRenderer found on " + gameObject.name);
        }
    }
}
