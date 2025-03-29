using UnityEngine;
using UnityEngine.EventSystems;

public class DraggableBook : MonoBehaviour, IPointerDownHandler
{
    public void OnPointerDown(PointerEventData eventData)
    {
        Debug.Log(gameObject.name + " was clicked! Dragging should work!");
    }
}
