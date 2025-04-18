using UnityEngine;

public class CustomButtonPrefab : MonoBehaviour
{
    // The level to switch to when this prefab button is clicked
    public string targetLevel;

    // Optional: reference to the visual component
    private SpriteRenderer spriteRenderer;

    // Colors
    public Color hoverColor = new Color(0f, 0.129f, 0.647f); // Blue
    public Color clickColor = new Color(1f, 1f, 1f);         // White
    public Color defaultColor = Color.white;

    // Cached reference to LevelManager (found at runtime)
    private LevelManager levelManager;

    void Start()
    {
        // Get visual component
        spriteRenderer = GetComponent<SpriteRenderer>();
        if (spriteRenderer != null)
            spriteRenderer.color = defaultColor;

        // Try to find LevelManager in the scene
        levelManager = FindObjectOfType<LevelManager>();
        if (levelManager == null)
        {
            Debug.LogWarning("⚠️ CustomButtonPrefab: LevelManager not found in scene!");
        }
    }

    void OnMouseOver()
    {
        if (spriteRenderer != null)
            spriteRenderer.color = hoverColor;
    }

    void OnMouseExit()
    {
        if (spriteRenderer != null)
            spriteRenderer.color = defaultColor;
    }

    void OnMouseDown()
    {
        if (spriteRenderer != null)
            spriteRenderer.color = clickColor;

        OnButtonClick();
    }

    void OnMouseUp()
    {
        if (spriteRenderer != null)
            spriteRenderer.color = hoverColor;
    }

    void OnButtonClick()
    {
        if (levelManager != null && !string.IsNullOrEmpty(targetLevel))
        {
            Debug.Log($"🟢 Button clicked! Switching to level: {targetLevel}");
            levelManager.SetActiveLevel(targetLevel);
        }
        else
        {
            Debug.LogWarning("⚠️ LevelManager is missing or targetLevel not set.");
        }
    }
}
