using UnityEngine;

public class ItemHover : MonoBehaviour
{

    // default values for the item glow and scale to allow changes in the unity ui
    public Color glowColor = Color.yellow;
    public float glowIntensity = 1.5f;

    public float itemScale = 1.1f;

    private SpriteRenderer spriteRenderer;
    private Color originalColor;
    private Vector3 originalScale;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        if(spriteRenderer != null )
        {
            originalColor = spriteRenderer.color;
            originalScale = transform.localScale;
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnMouseEnter()
    {
        if (spriteRenderer != null)
        {
            spriteRenderer.color = glowColor * glowIntensity;
            transform.localScale = originalScale * itemScale;
        }
    }

    void OnMouseExit()
    {
        if (spriteRenderer != null)
        {
            spriteRenderer.color = originalColor;
            transform.localScale = originalScale;
        }
    }
}
