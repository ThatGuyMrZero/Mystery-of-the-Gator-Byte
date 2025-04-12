using UnityEngine;

public class ClickableSprite : MonoBehaviour
{
    public GameObject chalkboard; // Reference to the chalkboard

    private Vector3 originalPosition;
    public float floatStrength = 0.1f;
    public float floatSpeed = 2f;

    private SpriteRenderer spriteRenderer;
    public Color highlightColor = Color.yellow;
    private Color originalColor;

    void Start()
    {
        originalPosition = transform.position;

        spriteRenderer = GetComponent<SpriteRenderer>();
        if (spriteRenderer != null)
        {
            originalColor = spriteRenderer.color;
            spriteRenderer.color = highlightColor; // Highlight it
        }
    }

    void Update()
    {
        // Floating animation
        float newY = Mathf.Sin(Time.time * floatSpeed) * floatStrength;
        transform.position = originalPosition + new Vector3(0, newY, 0);
    }

    void OnMouseDown()
    {
        // Only allow clicks if the chalkboard is NOT active
        if (chalkboard != null && !chalkboard.activeSelf)
        {
            chalkboard.SetActive(true);
        }
    }
}
