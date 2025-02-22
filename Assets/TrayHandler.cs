using UnityEngine;
using UnityEngine.EventSystems;
using System.Collections.Generic;

public class TrayHandler : MonoBehaviour, IDropHandler
{

    public List<Transform> stackPositions;
    private List<GameObject> stackedItems = new List<GameObject>();

    public void OnDrop(PointerEventData eventData)
    {
        GameObject droppedItem = eventData.pointerDrag;
        if (droppedItem != null && stackedItems.Count < stackPositions.Count)
        {
            ItemStack stackable = droppedItem.GetComponent<ItemStack>();
            if (stackable != null)
            {
                // implement this function after getting stacking working
                if (IsDuplicateLayer(stackable))
                {
                    Debug.Log("Cant add duplicate layers for " + stackable.name);
                    return;
                }

                int stackIndex = stackedItems.Count;
                droppedItem.transform.SetParent(transform);
                droppedItem.transform.position = stackPositions[stackIndex].position;
                droppedItem.transform.rotation = stackPositions[stackIndex].rotation;
                stackedItems.Add(droppedItem);

                Debug.Log("Stacked item " + droppedItem.name);
            }
        }
    }

    private bool IsDuplicateLayer(ItemStack stackable)
    {
        return false;
    }
}
