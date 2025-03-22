using UnityEngine;

public class ClickTest1 : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>(); // Get the sprite renderer
    }

    void OnMouseDown()
    {
        Debug.Log(gameObject.name + " was clicked!");
        if (spriteRenderer != null)
        {
            spriteRenderer.color = Color.red; // Change the book's color to red
        }
    }
}
