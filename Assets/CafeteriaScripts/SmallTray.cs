using UnityEngine;
using UnityEngine.EventSystems;

public class SmallTray : MonoBehaviour, IDropHandler
{
    private TrayHandler trayHandler;

    void Start()
    {
        trayHandler = FindFirstObjectByType<TrayHandler>();
    }

    public void OnDrop(PointerEventData eventData)
    {
        GameObject droppedItem = eventData.pointerDrag;
        if (droppedItem == null) return;
        Debug.Log($"Small tray received drop for {droppedItem.name}");

        if(trayHandler != null)
        {
            trayHandler.OnDrop(this, droppedItem);
        }
        else
        {
            Debug.Log($"No TrayHandler found in scene");
        }
    }
}
