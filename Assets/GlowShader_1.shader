using UnityEngine;

public class GlowOnHover : MonoBehaviour
{
    private Material objectMaterial;
    public Color hoverGlowColor = Color.yellow; // Glow color when hovered
    private Color originalColor;
    public float glowStrength = 5.0f; // Strength of the glow

    void Start()
    {
        // Get the material of the object
        objectMaterial = GetComponent<Renderer>().material;
        // Store the original color of the material
        originalColor = objectMaterial.GetColor("_Color");
    }

    void Update()
    {
        // Raycast to detect if the player is hovering over the object
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
        {
            // Check if the ray hits the object
            if (hit.collider.gameObject == gameObject)
            {
                // Change the glow effect when the player hovers
                objectMaterial.SetColor("_Color", hoverGlowColor);
                objectMaterial.SetFloat("_GlowStrength", glowStrength);
            }
            else
            {
                // Revert the glow effect when the player stops hovering
                objectMaterial.SetColor("_Color", originalColor);
                objectMaterial.SetFloat("_GlowStrength", 0);
            }
        }
    }
}
