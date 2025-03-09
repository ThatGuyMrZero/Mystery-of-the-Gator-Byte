using UnityEngine;
using UnityEngine.EventSystems;
using System.Collections.Generic;
using UnityEngine.UI;

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

                RectTransform itemRect = droppedItem.GetComponent<RectTransform>();
                Debug.Log($"Before Drop: {droppedItem.name} | Anchors: {itemRect.anchorMin}, {itemRect.anchorMax} | Size: {itemRect.sizeDelta} | Scale: {droppedItem.transform.localScale}");

                droppedItem.transform.SetParent(transform, false);
                droppedItem.transform.SetAsLastSibling();

           
                itemRect.anchorMin = new Vector2(0.5f, 0.5f);
                itemRect.anchorMax = new Vector2(0.5f, 0.5f);
                itemRect.pivot = new Vector2(0.5f, 0.5f);
                itemRect.anchoredPosition = stackPositions[stackedItems.Count].GetComponent<RectTransform>().anchoredPosition;

          
                itemRect.sizeDelta = new Vector2(100, 100);
                droppedItem.transform.localScale = Vector3.one;

          
                Canvas.ForceUpdateCanvases();
                itemRect.ForceUpdateRectTransforms();

                stackedItems.Add(droppedItem);

                Debug.Log($"After Drop: {droppedItem.name} | Anchors: {itemRect.anchorMin}, {itemRect.anchorMax} | Size: {itemRect.sizeDelta} | Scale: {droppedItem.transform.localScale}");




            }
        }
    }

    private bool IsDuplicateLayer(ItemStack stackable)
    {
        return false;
    }
}
