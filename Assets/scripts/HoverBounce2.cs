using UnityEngine;

public class HoverBounce2 : MonoBehaviour
{
    public float bounceHeight = 0.5f;   // Maximum height the object will move up and down
    public float bounceSpeed = 2f;      // Speed of the bounce (higher is faster)
    public Material glowingMaterial;    // Assign the glowing material in the Inspector
    private Material originalMaterial;  // Store the original material
    private Renderer objectRenderer;    // Renderer of the object
    private Vector3 initialPosition;    // Initial position of the object

    void Start()
    {
        // Store the initial position of the object
        initialPosition = transform.position;

        // Get the object's renderer component
        objectRenderer = GetComponent<Renderer>();
        
        // Store the original material
        if (objectRenderer != null)
        {
            originalMaterial = objectRenderer.material;
        }

        // Initially, set the object to the normal material (no glow)
        if (objectRenderer != null)
        {
            objectRenderer.material = originalMaterial;
        }
    }

    void Update()
    {
        // Apply a sine wave to the Y position to create a bouncing effect
        float newY = initialPosition.y + Mathf.Sin(Time.time * bounceSpeed) * bounceHeight;

        // Update the position of the object (only modify Y-axis for vertical movement)
        transform.position = new Vector3(initialPosition.x, newY, initialPosition.z);

        // Apply the glowing effect while hovering
        if (objectRenderer != null && glowingMaterial != null)
        {
            objectRenderer.material = glowingMaterial;  // Apply glowing material
        }
    }

    // Call this method to reset the material to normal
    public void ResetMaterial()
    {
        if (objectRenderer != null)
        {
            objectRenderer.material = originalMaterial; // Restore the original material
        }
    }
}
