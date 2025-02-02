using UnityEngine;
using UnityEngine.EventSystems;

public class DropZone : MonoBehaviour, IDropHandler
{
    public int maxBooks = 3;
    private int currentBooks = 0;

    public void OnDrop(PointerEventData eventData)
    {
        if (currentBooks < maxBooks)
        {
            GameObject droppedBook = eventData.pointerDrag;
            droppedBook.transform.position = transform.position + new Vector3(0, -currentBooks * 0.5f, 0); // Stack books
            droppedBook.transform.SetParent(transform);
            currentBooks++;

            GameManager.instance.CheckWinCondition();
        }
    }

    public int GetCurrentBookCount()
    {
        return currentBooks;
    }
}
