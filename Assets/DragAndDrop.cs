using UnityEngine;

public class DragAndDrop : MonoBehaviour
{
    private bool isDragging = false;
    private Vector3 offset;
    private Vector3 startPosition;
    private Collider2D currentDropZone = null; // Track current valid drop zone

    void Start()
    {
        startPosition = transform.position;
    }

    void OnMouseDown()
    {
        isDragging = true;
        offset = transform.position - GetMouseWorldPos();
    }

    void OnMouseUp()
    {
        isDragging = false;
        CheckDropZone();
    }

    void Update()
    {
        if (isDragging)
        {
            transform.position = GetMouseWorldPos() + offset;
        }
    }

    Vector3 GetMouseWorldPos()
    {
        Vector3 mousePoint = Input.mousePosition;
        mousePoint.z = Camera.main.WorldToScreenPoint(transform.position).z;
        return Camera.main.ScreenToWorldPoint(mousePoint);
    }

    void CheckDropZone()
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, 0.5f);
        Collider2D newDropZone = null;

        foreach (Collider2D col in colliders)
        {
            if (col.CompareTag("DropZone"))
            {
                Bounds dropZoneBounds = col.bounds;
                if (dropZoneBounds.Contains(transform.position)) // Ensure book is fully inside
                {
                    newDropZone = col;
                    break;
                }
            }
        }

        if (newDropZone != null) // If book is in a valid drop zone
        {
            if (currentDropZone != newDropZone) // If book is moving to a new zone
            {
                if (currentDropZone != null) // Remove book from previous zone
                {
                    SortingManager sortingManager = FindObjectOfType<SortingManager>();
                    if (sortingManager != null)
                    {
                        sortingManager.RemoveBookFromZone(currentDropZone.gameObject.name, gameObject);
                    }
                }

                transform.position = newDropZone.transform.position; // Snap to drop zone
                currentDropZone = newDropZone; // Update current zone

                // Notify sorting manager of new placement
                SortingManager sortingManager2 = FindObjectOfType<SortingManager>();
                if (sortingManager2 != null)
                {
                    sortingManager2.AddBookToZone(newDropZone.gameObject.name, gameObject);
                    //sortingManager2.CheckGameEnd(); // Check if game should end
                }
            }
        }
        else // If book is NOT placed in a valid zone, return to start position
        {
            if (currentDropZone != null) // Remove book from zone if dragged out
            {
                SortingManager sortingManager = FindObjectOfType<SortingManager>();
                if (sortingManager != null)
                {
                    sortingManager.RemoveBookFromZone(currentDropZone.gameObject.name, gameObject);
                }
                currentDropZone = null;
            }

            transform.position = startPosition; // Return book to start
        }
    }

}
