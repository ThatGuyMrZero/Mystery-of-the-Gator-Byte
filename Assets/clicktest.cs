using UnityEngine;

public class ClickableSquare : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
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
