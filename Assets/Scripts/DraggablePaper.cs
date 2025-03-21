using UnityEngine;

public class DraggablePaper : MonoBehaviour
{
    private Vector3 originalPosition;
    private Vector3 offset;
    private bool isDragging = false;

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

        Vector2 boxSize = new Vector2(0.5f, 0.5f);
        Collider2D[] hits = Physics2D.OverlapBoxAll(transform.position, boxSize, 0f);

        bool droppedOnZone = false;
        Paper paper = GetComponent<Paper>();

        foreach (Collider2D hit in hits)
        {
            if (hit.CompareTag("GradedZone") && paper.grade >= 50)
            {
                Vector3 randomOffset = new Vector3(Random.Range(-0.3f, 0.3f), Random.Range(-0.15f, 0.15f), 0);
                transform.position = hit.transform.position + randomOffset;

                Debug.Log("Paper graded correctly with increased random offset!");
                droppedOnZone = true;
                break;
            }
            else if (hit.CompareTag("NotGradedZone") && paper.grade < 50)
            {
                Vector3 randomOffset = new Vector3(Random.Range(-0.3f, 0.3f), Random.Range(-0.15f, 0.15f), 0);
                transform.position = hit.transform.position + randomOffset;

                Debug.Log("Paper discarded correctly with increased random offset!");
                droppedOnZone = true;
                break;
            }
        }

        if (!droppedOnZone)
        {
            Debug.Log("Invalid drop zone, returning to original position.");
            transform.position = originalPosition;
        }
        else
        {

            this.enabled = false;
        }
    }



    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireCube(transform.position, new Vector3(0.5f, 0.5f, 0));
    }
}
