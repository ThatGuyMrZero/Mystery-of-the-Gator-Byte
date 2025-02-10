using UnityEngine;

public class ClickableSquare : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();

        if (spriteRenderer == null)
        {
            Debug.LogError("SpriteRenderer not found! Make sure this object has a SpriteRenderer.");
        }

        if (GetComponent<Collider2D>() == null)
        {
            Debug.LogError("Collider2D not found! Add a BoxCollider2D to this object.");
        }
    }

    void OnMouseDown()
    {
        Debug.Log("Square clicked!");
        ChangeColor();
    }

    void ChangeColor()
    {
        spriteRenderer.color = new Color(Random.value, Random.value, Random.value);
    }
}
