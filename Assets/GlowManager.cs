using UnityEngine;

public class GlowManager : MonoBehaviour
{
    private Material objectMaterial; // Material Object reference 
    public Color hoverGlowColor = Color.white; // Glow color when hovered
    private Color originalColor;
    public float glowStrength = 5.0f;


    private void Start()
    {
        objectMaterial = GetComponent<Renderer>().material; // Access material property of the current object
        originalColor = objectMaterial.GetColor("_Color"); // Store the original color of the material
    }

    private void Update()
    {
        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition); // Convert screen position to world position for 2D raycasting

        RaycastHit2D hit = Physics2D.Raycast(mousePosition, Vector2.zero); // Cast a 2D ray to detect if the player is hovering over the object

        if (hit.collider != null) // Object hover check
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
                // Disable glow again if not hovering
                objectMaterial.SetColor("_Color", originalColor); 
                objectMaterial.SetFloat("_GlowStrength", 0);
                objectMaterial.SetFloat("_OutlineEnabled", 0); // Disable outline
            }
        }
        else
        {
            // Disable glow again if not hovering
            objectMaterial.SetColor("_Color", originalColor);
            objectMaterial.SetFloat("_GlowStrength", 0);
            objectMaterial.SetFloat("_OutlineEnabled", 0); // Disable outline
        }
    }
}
