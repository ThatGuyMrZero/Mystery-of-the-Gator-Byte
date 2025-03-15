using UnityEngine;

public class DragAndDrop : MonoBehaviour
{
    private bool isDragging = false;
    private Vector3 offset;
    private Vector3 startPosition;
    public Collider2D currentDropZone = null;

    [SerializeField] public string category; // Assign in Inspector

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
                DropZone dropZone = col.GetComponent<DropZone>();

                if (dropZone != null && dropZone.requiredCategory == category)
                {
                    newDropZone = col;
                    break;
                }
            }
        }

        if (newDropZone != null) // If the book is placed correctly
        {
            transform.position = newDropZone.transform.position;

            // If book is moving to a new drop zone, remove it from the old one
            if (currentDropZone != null && currentDropZone != newDropZone)
            {
                SortingManager sortingManager = FindFirstObjectByType<SortingManager>();
                if (sortingManager != null)
                {
                    sortingManager.RemoveBookFromZone(currentDropZone.gameObject.name, gameObject);
                }
            }

            currentDropZone = newDropZone; // Update zone

            // Notify SortingManager that book is placed correctly
            SortingManager sortingManager2 = FindFirstObjectByType<SortingManager>();
            if (sortingManager2 != null)
            {
                sortingManager2.AddBookToZone(newDropZone.gameObject.name, gameObject);
            }
        }
        else // If the book is NOT placed correctly, remove it from SortingManager
        {
            if (currentDropZone != null)
            {
                SortingManager sortingManager = FindFirstObjectByType<SortingManager>();
                if (sortingManager != null)
                {
                    sortingManager.RemoveBookFromZone(currentDropZone.gameObject.name, gameObject);
                }
                currentDropZone = null;
            }

            transform.position = startPosition; // Move book back
        }
    }


}
