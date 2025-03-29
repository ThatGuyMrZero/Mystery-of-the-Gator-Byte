using UnityEngine;
using UnityEngine.EventSystems;
using System.Collections.Generic;
using UnityEngine.UI;
using TMPro;

public class TrayHandler : MonoBehaviour, IDropHandler
{

    public List<Transform> stackPositions;
    private List<GameObject> stackedItems = new List<GameObject>();
    private List<string> currentOrder;
    public OrderGenerator orderManager;
    public TextMeshProUGUI scoreText;
    public int score = 0;

    void Start()
    {
        currentOrder = orderManager.GetActiveOrder(); // comes from the queue of orders in OrderGenerator.cs
        UpdateScoreUI();
    }


    public void OnDrop(PointerEventData eventData)
    {
        GameObject droppedItem = eventData.pointerDrag;
        if (droppedItem != null && stackedItems.Count < stackPositions.Count)
        {
            ItemStack stackable = droppedItem.GetComponent<ItemStack>();
            if (stackable != null)
            {
                // implement this function after getting stacking working
                //if (IsDuplicateLayer(stackable))
                //{
                //    Debug.Log("Cant add duplicate layers for " + stackable.name);
                //    return;
                //}

                string itemName = stackable.name;
                int stackIndex = stackedItems.Count;

                Debug.Log($"Item name: {itemName}, stack index: {stackIndex}, Order Item Name: {currentOrder[stackIndex]}");

                if (stackIndex < currentOrder.Count && itemName == currentOrder[stackIndex])
                {
                    RectTransform itemRect = droppedItem.GetComponent<RectTransform>();
                    //Debug.Log($"Before Drop: {droppedItem.name} | Anchors: {itemRect.anchorMin}, {itemRect.anchorMax} | Size: {itemRect.sizeDelta} | Scale: {droppedItem.transform.localScale}");

                    droppedItem.transform.SetParent(transform, false);
                    droppedItem.transform.SetAsLastSibling();

                    itemRect.anchorMin = new Vector2(0.5f, 0.5f);
                    itemRect.anchorMax = new Vector2(0.5f, 0.5f);
                    itemRect.pivot = new Vector2(0.5f, 0.5f);
                    itemRect.anchoredPosition = stackPositions[stackedItems.Count].GetComponent<RectTransform>().anchoredPosition;

                    //itemRect.sizeDelta = new Vector2(100, 100);
                    //droppedItem.transform.localScale = Vector3.one;

                    stackedItems.Add(droppedItem);
                    score += 10;
                    UpdateScoreUI();

                    if (stackedItems.Count == currentOrder.Count)
                    {
                        Debug.Log("Order complete");
                        stackedItems.Clear();
                        orderManager.CompleteOrder();
                        currentOrder = orderManager.GetActiveOrder();
                    }


                    //Canvas.ForceUpdateCanvases();
                    //itemRect.ForceUpdateRectTransforms();

                    //stackedItems.Add(droppedItem);

                    //Debug.Log($"After Drop: {droppedItem.name} | Anchors: {itemRect.anchorMin}, {itemRect.anchorMax} | Size: {itemRect.sizeDelta} | Scale: {droppedItem.transform.localScale}");
                }
                else
                {
                    Debug.Log("Incorrect item, game over");
                    GameOver();
                }

                




            }
        }
    }

    private void UpdateScoreUI()
    {
        scoreText.text = "Score: " + score;
    }

    private void GameOver()
    {
        scoreText.text = "Game Over";
        Time.timeScale = 0;
    }

    private bool IsDuplicateLayer(ItemStack stackable)
    {
        return false;
    }
}
