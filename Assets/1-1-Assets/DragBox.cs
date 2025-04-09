using UnityEngine;

public class DragBox : MonoBehaviour
{
    private bool isDragging = false;
    private Vector3 offset;
    private Vector3 originalPosition;

    void Start()
    {
        // Store the original position when the game starts
        originalPosition = transform.position;
    }

    void OnMouseDown()
    {
        isDragging = true;

        // Calculate the offset between mouse position and object position
        Vector3 mouseWorldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        offset = transform.position - new Vector3(mouseWorldPos.x, mouseWorldPos.y, transform.position.z);
    }

    void OnMouseUp()
    {
        isDragging = false;

        // Snap back to the original position
        transform.position = originalPosition;
    }

    void Update()
    {
        if (isDragging)
        {
            Vector3 mouseWorldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            transform.position = new Vector3(mouseWorldPos.x, mouseWorldPos.y, transform.position.z) + offset;
        }
    }
}
