using UnityEngine;

public class CustomButton : MonoBehaviour
{
    // Reference to the LevelManager to switch levels
    public LevelManager levelManager;

    // The target level to switch to when the button is clicked
    public string targetLevel;  // You can set this in the Inspector for each button

    // Optional: Reference to the visual sprite renderer to change colors when hovered
    private SpriteRenderer spriteRenderer;
    
    // Set the hover and click colors
    public Color hoverColor = new Color(0f, 0.129f, 0.647f);  // Light Blue (0, 33, 165)
    public Color clickColor = new Color(0.980f, 0.275f, 0.086f);  // Light Orange (250, 70, 22)

    public Color defaultColor = Color.white;

    void Start()
    {
        // Get the SpriteRenderer component to change its color
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.color = defaultColor;
    }

    void OnMouseOver()
    {
        // Change the button's color when hovered over
        spriteRenderer.color = hoverColor;
    }

    void OnMouseExit()
    {
        // Revert back to the default color when mouse leaves
        spriteRenderer.color = defaultColor;
    }

    void OnMouseDown()
    {
        // Change the color when clicked and perform an action
        spriteRenderer.color = clickColor;
        OnButtonClick();  // Call the action for the button press
    }

    void OnMouseUp()
    {
        // Revert to hover color when mouse button is released
        spriteRenderer.color = hoverColor;
    }

    // The action to perform when the button is clicked
    void OnButtonClick()
    {
        Debug.Log("Button clicked! Switching to " + targetLevel);
        
        // Call SetActiveLevel on LevelManager to switch to the target level
        if (levelManager != null && !string.IsNullOrEmpty(targetLevel))
        {
            levelManager.SetActiveLevel(targetLevel);  // Switch to the specified target level
        }
    }
}
