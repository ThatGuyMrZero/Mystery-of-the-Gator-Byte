using UnityEngine;
using UnityEngine.Rendering;

public class DragNumbers : MonoBehaviour
{
    private bool isDragging = false;
    private Vector3 offset;
    private Vector3 origPos;

    public Transform snapTarget;
    public float snapRange = 0.5f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        origPos = transform.position;
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

            // Check if close to snap target
            if (Vector3.Distance(transform.position, snapTarget.position) <= snapRange)
            {
                transform.position = snapTarget.position;
            }
        }
    }
}
