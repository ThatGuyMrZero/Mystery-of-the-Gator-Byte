using UnityEngine;
using UnityEngine.EventSystems;

public class DraggableBook : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    private Vector3 startPosition;
    private Transform originalParent;
    private CanvasGroup canvasGroup;

    void Awake()
    {
        canvasGroup = gameObject.AddComponent<CanvasGroup>(); // Allows transparency while dragging
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        startPosition = transform.position;
        originalParent = transform.parent;
        canvasGroup.blocksRaycasts = false; // Prevents drop detection issues
    }

    public void OnDrag(PointerEventData eventData)
    {
        transform.position = Input.mousePosition; // Moves book to cursor position
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        canvasGroup.blocksRaycasts = true; // Reactivate raycasting after dropping
    }
}
