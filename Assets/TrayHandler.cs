using UnityEngine;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using TMPro;
using System.Linq;

public class TrayHandler : MonoBehaviour
{
    // new stuff
    public RectTransform trayContainer;
    public GameObject smallTrayPrefab;
    private List<GameObject> traySlots = new List<GameObject>();
    private Dictionary<SmallTray, GameObject> trayContents = new Dictionary<SmallTray,GameObject>();
    public float traySpacing = 120f;

    public GameObject incorrectOrderPopup;
    public float popupDuration = 3f;

    public ScoreManager scoremanager;


    // old stuff not being used rn
    //public List<Transform> stackPositions;
    //private List<GameObject> stackedItems = new List<GameObject>();

    // original stuff still being used
    private List<string> currentOrder;
    public OrderGenerator orderManager;
    public TextMeshProUGUI scoreText;
    public int score = 0;

    //public GameManager gamemanager;

    void OnEnable()
    {
        GameManager.OnGameStart += StartGame;
    }

    void OnDisable()
    {
        GameManager.OnGameStart -= StartGame;
    }

    void Start()
    {
        incorrectOrderPopup.SetActive(false);
        //currentOrder = orderManager.GetActiveOrder();
        //GenerateTrays(currentOrder.Count);
        //scoremanager.StartOrderScoring();
        //UpdateScoreUI();
    }

    private void StartGame()
    {
        currentOrder = orderManager.GetActiveOrder();
        GenerateTrays(currentOrder.Count);
        scoremanager.StartOrderScoring();
        UpdateScoreUI();
        
    }


    public void OnDrop(SmallTray tray, GameObject droppedItem)
    {
        if (droppedItem == null) return;

        Debug.Log($"TrayHandler received drop for {droppedItem.name} on {tray.name}");

        PlaceItemInTray(tray.gameObject, droppedItem);
    }

    private void PlaceItemInTray(GameObject trayObject, GameObject newItem)
    {
        SmallTray tray = trayObject.GetComponent<SmallTray>();

        if (tray == null)
        {
            Debug.Log($"SmallTray component not found on {trayObject.name}");
            return;
        }

        if (trayContents.ContainsKey(tray) && trayContents[tray] != null)
        {
            Debug.Log($"Replacing {trayContents[tray].name} with {newItem.name} in {tray.name}");
            Destroy(trayContents[tray]);
        }

        trayContents[tray] = newItem;

        RectTransform itemRect = newItem.GetComponent<RectTransform>();
        newItem.transform.SetParent(tray.transform, false);
        newItem.transform.SetAsLastSibling();
        itemRect.anchoredPosition = Vector2.zero;
        Debug.Log($"Placed {newItem.name} in {tray.name}");
        //CheckIfOrderCompleted();
    }

    private GameObject GetClosestEmptyTray(Vector2 dropPosition)
    {
        foreach (GameObject tray in traySlots)
        {
            RectTransform trayRect = tray.GetComponent<RectTransform>();

            if (RectTransformUtility.RectangleContainsScreenPoint(trayRect, dropPosition, null))
            {
                return tray;
            }
        }
        return null;
    }

    private void GenerateTrays(int count)
    {
        foreach (GameObject tray in traySlots)
        {
            Destroy(tray);
        }
        traySlots.Clear();
        trayContents.Clear();

        float startX = -((count - 1) * traySpacing) / 2;

        for (int i = 0; i < count; i++)
        {
            GameObject newTray = Instantiate(smallTrayPrefab, trayContainer);
            RectTransform trayRect = newTray.GetComponent<RectTransform>();
            trayRect.anchoredPosition = new Vector2(startX + (i * traySpacing), 0);
            traySlots.Add(newTray);
        }
    }

    private void CheckIfOrderCompleted()
    {
        List<string> placedItems = new List<string>();

        foreach (var entry in trayContents)
        {
            placedItems.Add(entry.Value.name);
        }

        if (placedItems.Count == currentOrder.Count && !currentOrder.Except(placedItems).Any())
        {
            Debug.Log("Order Complete!");
            score += 50;
            UpdateScoreUI();
            orderManager.CompleteOrder();
            currentOrder = orderManager.GetActiveOrder();
            GenerateTrays(currentOrder.Count);
        }
    }


    private void UpdateScoreUI()
    {
        scoreText.text = "Score: " + scoremanager.totalScore;
    }

    // not using rn, might delete
    private void GameOver()
    {
        scoreText.text = "Game Over";
        Time.timeScale = 0;
    }

    public void CheckOrder()
    {
        // new function for checking order on button press
        // old function is CheckIfOrderCompleted

        if(currentOrder == null)
        {
            Debug.Log("No active order");
            return;
        }

        List<string> placedIngredients = new List<string>();
        foreach (var tray in trayContents)
        {
            if (tray.Value != null)
            {
                placedIngredients.Add(tray.Value.tag);
            }   
        }


        Debug.Log("Tray Contents:");
        foreach (var entry in trayContents)
        {
            string ingredientTag = entry.Value != null ? entry.Value.tag : "EMPTY";
            Debug.Log("Tray " + entry.Key.name + ": " + ingredientTag);
        }

        Debug.Log("Placed Ingredients: " + string.Join(", ", placedIngredients));
        Debug.Log("Expected Order: " + string.Join(", ", currentOrder));



        bool orderMatched = false;

        if ((placedIngredients.Count == currentOrder.Count) &&(!currentOrder.Except(placedIngredients).Any()))
        {
            orderMatched = true;
        }

        if (orderMatched)
        {
            incorrectOrderPopup.SetActive(false);
            Debug.Log("Order Complete");

            //score += 50;
            scoremanager.CompleteOrderScoring();
            UpdateScoreUI();
            orderManager.CompleteOrder();
            currentOrder = orderManager.GetActiveOrder();
            if (currentOrder != null)
            { 
                GenerateTrays(currentOrder.Count);
            }
            else
            {
                Debug.Log("Current order is null");
                GenerateTrays(0);
            }
        
        }
        else
        {
            Debug.Log("Order is incorrect or incomplete");
            StartCoroutine(ShowIncorrectOrderPopup(popupDuration));
        }

    }

    private IEnumerator ShowIncorrectOrderPopup(float duration)
    {
        incorrectOrderPopup.SetActive(true);
        yield return new WaitForSeconds(duration);
        incorrectOrderPopup.SetActive(false);
    }

    private void calculateScore(float startTime, float endTime)
    {

    }

}
