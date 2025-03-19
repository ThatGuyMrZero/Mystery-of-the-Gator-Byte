using UnityEngine;
using UnityEngine.EventSystems;

public class DragBox : MonoBehaviour, IDragHandler, IEndDragHandler
{
    public string boxType; // "string", "int", "bool"
    private Vector3 startPosition;

    private void Start()
    {
        startPosition = transform.position;  // Save original position
    }

    public void OnDrag(PointerEventData eventData)
    {
        transform.position = Input.mousePosition;  // Follow mouse position
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        // Snap the box back to the original position if not dropped in the correct place
        transform.position = startPosition; 
    }
}
