using UnityEngine;
using UnityEngine.EventSystems;

public class DraggableBook : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    private Vector3 startPosition;
    private Transform parentAfterDrag;

    public void OnBeginDrag(PointerEventData eventData)
    {
        startPosition = transform.position;
        parentAfterDrag = transform.parent;
        GetComponent<CanvasGroup>().blocksRaycasts = false;
    }

    public void OnDrag(PointerEventData eventData)
    {
        transform.position = Input.mousePosition;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        GetComponent<CanvasGroup>().blocksRaycasts = true;
    }
}
