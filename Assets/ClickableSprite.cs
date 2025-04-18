using UnityEngine;

public class ClickableSprite : MonoBehaviour
{
    public GameObject chalkboard;
    public GameObject instructionsSprite;

    private Vector3 originalPosition;
    public float floatStrength = 0.1f;
    public float floatSpeed = 2f;

    private SpriteRenderer spriteRenderer;
    public Color highlightColor = Color.yellow;
    private Color originalColor;

    private bool hasBeenClicked = false;

    void Start()
    {
        originalPosition = transform.position;

        spriteRenderer = GetComponent<SpriteRenderer>();
        if (spriteRenderer != null)
        {
            originalColor = spriteRenderer.color;
            spriteRenderer.color = highlightColor;
        }

        if (instructionsSprite != null)
        {
            instructionsSprite.SetActive(false);
        }
    }

    void Update()
    {
        float newY = Mathf.Sin(Time.time * floatSpeed) * floatStrength;
        transform.position = originalPosition + new Vector3(0, newY, 0);
    }

    void OnMouseDown()
    {
        if (chalkboard != null && !chalkboard.activeSelf)
        {
            chalkboard.SetActive(true);

            if (!hasBeenClicked && instructionsSprite != null)
            {
                instructionsSprite.SetActive(true);
                hasBeenClicked = true;
            }
        }
    }
}
