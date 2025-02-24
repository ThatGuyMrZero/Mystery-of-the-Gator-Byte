using UnityEngine;

public class GlowManager2D : MonoBehaviour
{
    private Material objectMaterial;
    public Color hoverGlowColor = Color.white; // Glow color when hovered
    private Color originalColor;
    public float glowStrength = 5.0f; // Strength of the glow

    private void Start()
    {
        // Get the material of the object
        objectMaterial = GetComponent<Renderer>().material;
        // Store the original color of the material
        originalColor = objectMaterial.GetColor("_Color");
    }

    private void Update()
    {
        // Convert screen position to world position for 2D raycasting
        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        // Cast a 2D ray to detect if the player is hovering over the object
        RaycastHit2D hit = Physics2D.Raycast(mousePosition, Vector2.zero);

        if (hit.collider != null)
        {
            // Check if the ray hits this object
            if (hit.collider.gameObject == gameObject)
            {
                // Enable outline and change the glow effect when the player hovers
                objectMaterial.SetColor("_Color", hoverGlowColor);
                objectMaterial.SetFloat("_GlowStrength", glowStrength);
                objectMaterial.SetFloat("_OutlineEnabled", 1); // Enable outline
            }
            else
            {
                // Revert the glow effect and disable outline when the player stops hovering
                objectMaterial.SetColor("_Color", originalColor);
                objectMaterial.SetFloat("_GlowStrength", 0);
                objectMaterial.SetFloat("_OutlineEnabled", 0); // Disable outline
            }
        }
        else
        {
            // Revert the glow effect and disable outline if not hovering
            objectMaterial.SetColor("_Color", originalColor);
            objectMaterial.SetFloat("_GlowStrength", 0);
            objectMaterial.SetFloat("_OutlineEnabled", 0); // Disable outline
        }
    }
}
