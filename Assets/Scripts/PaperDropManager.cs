using UnityEngine;
using System.Collections;

public class PaperDropManager : MonoBehaviour
{
    public static PaperDropManager Instance;

    [Header("Drop Settings")]
    public int totalPapers = 10;
    private int droppedCount = 0;

    [Header("Win Message UI")]
    public GameObject winMessagePanel;

    [Header("References")]
    public PaperSpawner paperSpawner;

    void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }

    public void PaperDroppedCorrectly()
    {
        droppedCount++;
        Debug.Log($"Paper dropped correctly: {droppedCount} / {totalPapers}");

        if (droppedCount >= totalPapers)
        {
            if (winMessagePanel != null)
            {
                winMessagePanel.SetActive(true);
                Debug.Log("Nicely done!");
            }
            StartCoroutine(WaitAndResetBoard());
        }
    }

    private IEnumerator WaitAndResetBoard()
    {
        yield return new WaitForSeconds(3f);
        if (winMessagePanel != null)
            winMessagePanel.SetActive(false);
        if (paperSpawner != null)
        {
            Debug.Log("Calling ResetBoard on PaperSpawner.");
            paperSpawner.ResetBoard();
        }
        else
        {
            Debug.LogError("PaperSpawner reference is null in PaperDropManager!");
        }
        droppedCount = 0;
    }

}
