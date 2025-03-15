using UnityEngine;

public class DragAndDrop : MonoBehaviour
{
    private bool isDragging = false;
    private Vector3 offset;
    private Vector3 startPosition;
    private Collider2D currentDropZone = null;

    [SerializeField] private string category; // Assign in Inspector

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

        if (newDropZone != null)
        {
            transform.position = newDropZone.transform.position;
            currentDropZone = newDropZone;
        }
        else
        {
            transform.position = startPosition;
        }
    }
}
