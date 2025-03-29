using UnityEngine;
using UnityEngine.EventSystems;

public class ItemSpawner : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    
    private GameObject draggedItem;
    private RectTransform rectTransform;
    private CanvasGroup canvasGroup;
    private Vector2 originalPosition;
    private Transform originalParent;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rectTransform = GetComponent<RectTransform>();
        canvasGroup = GetComponent<CanvasGroup>();
        originalPosition = rectTransform.anchoredPosition;
        originalParent = transform.parent;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        draggedItem = Instantiate(gameObject, originalParent);
        draggedItem.transform.SetParent(rectTransform.root, false);
        draggedItem.GetComponent<CanvasGroup>().blocksRaycasts = false;
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (draggedItem != null)
        {
            draggedItem.GetComponent<RectTransform>().anchoredPosition += eventData.delta;
        }
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        if (draggedItem != null)
        {
            draggedItem.GetComponent<CanvasGroup>().blocksRaycasts = true;

            if (ValidDropLocation(draggedItem))
            {
                Destroy(draggedItem);
                SpawnNewItem();
            }
            else
            {
                Destroy(draggedItem);
            }
            draggedItem = null;
        }
    }

    private bool ValidDropLocation(GameObject item)
    {
        TrayHandler tray = FindObjectOfType<TrayHandler>();
        RectTransform trayRect = tray.GetComponent<RectTransform>();
        return RectTransformUtility.RectangleContainsScreenPoint(trayRect, item.GetComponent<RectTransform>().position, null);
    }

    private void SpawnNewItem()
    {
        GameObject newItem = Instantiate(gameObject, originalParent);
        newItem.GetComponent<RectTransform>().anchoredPosition = originalPosition;
    }
}
