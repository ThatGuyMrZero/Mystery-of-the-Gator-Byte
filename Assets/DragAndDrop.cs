using UnityEngine;

public class DragAndDrop : MonoBehaviour
{
    private bool isDragging = false;
    private Vector3 offset;
    private Vector3 startPosition;

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
        foreach (Collider2D col in colliders)
        {
            if (col.CompareTag("DropZone"))
            {
                Debug.Log($"{gameObject.name} dropped into {col.gameObject.name}");

                SortingManager sortingManager = FindObjectOfType<SortingManager>();
                if (sortingManager != null)
                {
                    sortingManager.AddBookToZone(col.gameObject.name, gameObject);
                }

                return; // Stop checking after finding the first drop zone
            }
        }
    }
}
