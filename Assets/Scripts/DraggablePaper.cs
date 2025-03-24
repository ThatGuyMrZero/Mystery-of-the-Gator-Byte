using UnityEngine;

public class DraggablePaper : MonoBehaviour
{
    private Vector3 originalPosition;
    private Vector3 offset;
    private bool isDragging = false;

    [Header("Drop Detection Area")]
    [SerializeField] private Vector2 dropDetectionSize = new Vector2(3.5f, 5.5f); // Visible in Inspector

    [Header("Random Drop Offset")]
    [SerializeField] private float maxOffsetX = 0.3f;
    [SerializeField] private float maxOffsetY = 0.1f;

    void OnMouseDown()
    {
        originalPosition = transform.position;

        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        offset = transform.position - new Vector3(mousePos.x, mousePos.y, transform.position.z);
        isDragging = true;
    }

    void OnMouseDrag()
    {
        if (isDragging)
        {
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            transform.position = new Vector3(mousePos.x, mousePos.y, transform.position.z) + offset;
        }
    }

    void OnMouseUp()
    {
        isDragging = false;

        Collider2D[] hits = Physics2D.OverlapBoxAll(transform.position, dropDetectionSize, 0f);

        bool droppedOnZone = false;
        Paper paper = GetComponent<Paper>();

        foreach (Collider2D hit in hits)
        {
            if (hit.CompareTag("GradedZone") && paper.grade >= 50)
            {
                SnapToZone(hit);
                Debug.Log("Paper graded correctly!");
                droppedOnZone = true;
                break;
            }
            else if (hit.CompareTag("NotGradedZone") && paper.grade < 50)
            {
                SnapToZone(hit);
                Debug.Log("Paper discarded correctly!");
                droppedOnZone = true;
                break;
            }
        }

        if (!droppedOnZone)
        {
            Debug.Log("Invalid drop zone. Returning to original position.");
            transform.position = originalPosition;
        }
        else
        {
            this.enabled = false; // Disable dragging after a successful drop
        }
    }

    private void SnapToZone(Collider2D zone)
    {
        Vector3 randomOffset = new Vector3(
            Random.Range(-maxOffsetX, maxOffsetX),
            Random.Range(-maxOffsetY, maxOffsetY),
            0
        );

        transform.position = zone.transform.position + randomOffset;
    }

    // Optional: Visualize the drop detection area in the Scene view
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireCube(transform.position, new Vector3(dropDetectionSize.x, dropDetectionSize.y, 0));
    }
}
