using UnityEngine;

public class HoverBounce : MonoBehaviour
{
    public float bounceHeight = 0.5f; // Maximum height the object will move up and down
    public float bounceSpeed = 2f;    // Speed of the bounce (higher is faster)
    private Vector3 initialPosition;  // Initial position of the object
    private bool isHovering = false;  // Flag to control whether the object is bouncing
    private Renderer objectRenderer;  // The renderer to modify material properties
    private Material originalMaterial; // Store the original material
    public Material glowingMaterial;   // Assign the glowing material in the Inspector

    void Start()
    {
        // Store the initial position of the object
        initialPosition = transform.position;
        objectRenderer = GetComponent<Renderer>();  // Get the renderer of the object

        // Store the original material of the object
        if (objectRenderer != null)
        {
            originalMaterial = objectRenderer.material;
        }
    }

    void Update()
    {
        if (isHovering)
        {
            // Apply a sine wave to the Y position to create a bouncing effect
            float newY = initialPosition.y + Mathf.Sin(Time.time * bounceSpeed) * bounceHeight;

            // Update the position of the object (only modify Y-axis for vertical movement)
            transform.position = new Vector3(initialPosition.x, newY, initialPosition.z);
        }
    }

    // Call this method to start hovering
    public void StartHovering()
    {
        isHovering = true; // Enable hovering

        // Enable the glowing effect
        if (objectRenderer != null && glowingMaterial != null)
        {
            objectRenderer.material = glowingMaterial; // Change the material to glowing
        }
    }

    // Call this method to stop hovering
    public void StopHovering()
    {
        isHovering = false; // Disable hovering

        // Restore the original material when the hover effect stops
        if (objectRenderer != null && originalMaterial != null)
        {
            objectRenderer.material = originalMaterial; // Restore original material
        }
    }
}
