using UnityEngine;
using UnityEngine.EventSystems;


public class ItemStack : MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler
{

    private RectTransform rectTransform;
    private CanvasGroup canvasGroup;
    private ItemSpawner spawner;
    private Transform spawnParent;

    //public GameManager gamemanager;

    //void OnEnable()
    //{
    //    GameManager.OnGameStart += StartGame;
    //}

    //void OnDisable()
    //{
    //    GameManager.OnGameStart -= StartGame;
    //}


    void Start()
    {
        rectTransform = GetComponent<RectTransform>();
        canvasGroup = GetComponent<CanvasGroup>();
        spawnParent = transform.parent;
    }

    public void SetSpawner(ItemSpawner itemSpawner)
    {
        spawner = itemSpawner;
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        canvasGroup.alpha = 0.6f;
        canvasGroup.blocksRaycasts = false;

        if (spawner != null && transform.parent == spawnParent)
        {
            spawner.SpawnNewItem();
        }
    }

    public void OnDrag(PointerEventData eventData)
    {
        rectTransform.anchoredPosition += eventData.delta;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        canvasGroup.alpha = 1f;
        canvasGroup.blocksRaycasts = true;

        GameObject closestTray = GetClosestTray(eventData.position);

        if (closestTray != null)
        {
            SmallTray smallTray = closestTray.GetComponent<SmallTray>();

            if (smallTray != null)
            {
                Debug.Log($"Valid drop for {gameObject.name} on {smallTray.name}");
                SnapToTray(closestTray);
                return;
            }
        }
        Debug.Log($"Invalid drop for {gameObject.name}, destroying dragged item");
        Destroy(gameObject);
    }

    private GameObject GetClosestTray(Vector2 dropPosition)
    {
        foreach (SmallTray tray in FindObjectsByType<SmallTray>(FindObjectsSortMode.None))
        {
            RectTransform trayRect = tray.GetComponent<RectTransform>();

            if (RectTransformUtility.RectangleContainsScreenPoint(trayRect, dropPosition, Camera.main))
            {
                Debug.Log($"Detected tray {tray.name} under mouse");
                return tray.gameObject; 
            }
        }

        Debug.Log("No tray detected under mouse");
        return null;
    }


    private void SnapToTray(GameObject tray)
    {
        transform.SetParent(tray.transform, false);
        transform.SetAsLastSibling();
        rectTransform.anchoredPosition = Vector2.zero;

    }

}
