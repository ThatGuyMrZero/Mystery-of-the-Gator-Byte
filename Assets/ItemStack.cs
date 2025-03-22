using UnityEngine;
using UnityEngine.EventSystems;


public class ItemStack : MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler
{
    public GameObject prefabToSpawn;
    public bool isPizzaTopping = false;
    private RectTransform rectTransform;
    private CanvasGroup canvasGroup;
    private Transform originalParent;
    private Vector2 originalPosition;

    void Start()
    {
        rectTransform = GetComponent<RectTransform>();
        canvasGroup = GetComponent<CanvasGroup>();
    }
    
    public void OnBeginDrag(PointerEventData eventData)
    {
        canvasGroup.alpha = 0.6f;
        canvasGroup.blocksRaycasts = false;
        originalParent = transform.parent;
        originalPosition = rectTransform.anchoredPosition;
    }

    public void OnDrag(PointerEventData eventData)
    {
        rectTransform.anchoredPosition += eventData.delta;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        canvasGroup.alpha = 1f;
        canvasGroup.blocksRaycasts = true;

        GameObject tray = GameObject.Find("Tray");
        RectTransform trayRect = tray.GetComponent<RectTransform>();

        if (RectTransformUtility.RectangleContainsScreenPoint(trayRect, Input.mousePosition, Camera.main))
        {
            Debug.Log("Dropped on tray: " + gameObject.name);
            transform.SetParent(tray.transform, false);
            transform.SetAsLastSibling();
            rectTransform.anchoredPosition = Vector2.zero;
        }
        else
        {
            Debug.Log("Not on tray, returning to start.");
            transform.SetParent(originalParent);
            rectTransform.anchoredPosition = originalPosition;
        }

    }

    // dont need ondrop here since we use it inside trayhandler now instead to stack properly on the tray

    //public void OnDrop(PointerEventData eventData)
    //{
    //    GameObject droppedItem = eventData.pointerDrag;

    //    if (droppedItem != null)
    //    {
    //        ItemStack stackable = droppedItem.GetComponent<ItemStack>();
    //        if(stackable != null)
    //        {
    //            if(stackable.isPizzaTopping && stackable.prefabToSpawn != null)
    //            {
    //                SpawnToppings(stackable.prefabToSpawn, rectTransform);
    //            }
    //            else
    //            {
    //                droppedItem.transform.SetParent(transform);
    //                droppedItem.transform.localPosition = Vector3.zero;
    //            }
    //        }
    //    }
    //}


    private void SpawnToppings(GameObject prefab, Transform parent)
    {
        int numToppings = 5;
        float radius = 0.3f;

        for(int i=0; i<numToppings; i++)
        {
            Vector3 randomOffset = new Vector3(
                Random.Range(-radius, radius),
                Random.Range(-radius, radius),
                0
            );

            GameObject newTopping = Instantiate(prefab, parent.position + randomOffset, Quaternion.identity);
            newTopping.transform.SetParent(parent);
        }
    }

}
