using UnityEngine;
using UnityEngine.Rendering;

public class DragNumbers : MonoBehaviour
{
    private bool isDragging = false;
    private Vector3 offset;
    private Vector3 origPos;

    public Transform[] snapTargets;
    public float snapRange = 0.5f;
    private WinConditionManager wcm;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        origPos = transform.position;
        wcm = FindAnyObjectByType<WinConditionManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Collider2D hitCollider = Physics2D.OverlapPoint(mousePos);

            if (hitCollider != null && hitCollider.transform == transform)
            {
                isDragging = true;
                offset = transform.position - mousePos;
            }
        }

        if (isDragging)
        {
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            transform.position = mousePos + offset;
        }

        if (Input.GetMouseButtonUp(0))
        {
            isDragging = false;

            float closestDistance = Mathf.Infinity;
            Transform closestTarget = null;

            foreach (Transform target in snapTargets)
            {
                float distance = Vector3.Distance(transform.position, target.position);
                if (distance < closestDistance)
                {
                    closestDistance = distance;
                    closestTarget = target;
                }
            }

            if (closestDistance <= snapRange && closestTarget != null)
            {
                transform.position = closestTarget.position;
            }

            if (wcm != null)
            {
                wcm.CheckWinCondition();
            }
        }
    }

    public void SnapBackToPosition()
    {
        transform.position = origPos;
    }

    public void SetSnapTargets(Transform[] newTargets)
    {
        snapTargets = newTargets;
    }
}
