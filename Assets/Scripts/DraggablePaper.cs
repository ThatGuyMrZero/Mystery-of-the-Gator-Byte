using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class DraggablePaper : MonoBehaviour
{
    private Vector3 originalPosition;
    private Vector3 offset;
    private bool isDragging = false;

    [SerializeField] private Vector2 dropDetectionSize = new Vector2(0.5f, 0.5f);

    [SerializeField] private float dropRandomXMin = -10f;
    [SerializeField] private float dropRandomXMax = 10f;
    [SerializeField] private float dropRandomYMin = -10f;
    [SerializeField] private float dropRandomYMax = 10f;

    public GameObject errorMessage;

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
                Vector3 randomOffset = new Vector3(
                    Random.Range(dropRandomXMin, dropRandomXMax),
                    Random.Range(dropRandomYMin, dropRandomYMax),
                    0);
                transform.position = hit.transform.position + randomOffset;
                Debug.Log("Paper graded correctly with drop offset!");
                droppedOnZone = true;

                DropZoneTransparency dz = hit.GetComponent<DropZoneTransparency>();
                if (dz != null)
                {
                    dz.MakeTransparent();
                }
                break;
            }
            else if (hit.CompareTag("NotGradedZone") && paper.grade < 50)
            {
                Vector3 randomOffset = new Vector3(
                    Random.Range(dropRandomXMin, dropRandomXMax),
                    Random.Range(dropRandomYMin, dropRandomYMax),
                    0);
                transform.position = hit.transform.position + randomOffset;
                Debug.Log("Paper discarded correctly with drop offset!");
                droppedOnZone = true;

                DropZoneTransparency dz = hit.GetComponent<DropZoneTransparency>();
                if (dz != null)
                {
                    dz.MakeTransparent();
                }
                break;
            }
        }

        if (!droppedOnZone)
        {
            Debug.Log("Invalid drop zone, returning to original position.");
            transform.position = originalPosition;
            if (errorMessage != null)
            {
                StartCoroutine(ShowErrorMessage());
            }
        }
        else
        {
            transform.SetAsLastSibling();
            this.enabled = false;
        }
    }

    private IEnumerator ShowErrorMessage()
    {
        errorMessage.SetActive(true);
        yield return new WaitForSeconds(1f);
        errorMessage.SetActive(false);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireCube(transform.position, new Vector3(dropDetectionSize.x, dropDetectionSize.y, 0));
    }
}
