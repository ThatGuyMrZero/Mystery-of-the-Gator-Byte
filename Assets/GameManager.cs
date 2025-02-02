using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance; // Singleton instance

    public GameObject chalkboard;
    public GameObject winMessage;

    private DropZone[] dropZones;

    void Awake()
    {
        if (instance == null)
        {
            instance = this; // Assign this instance
        }
    }

    void Start()
    {
        dropZones = FindObjectsOfType<DropZone>();
        winMessage.SetActive(false);
    }

    public void CheckWinCondition()
    {
        int totalBooks = 0;

        foreach (DropZone zone in dropZones)
        {
            totalBooks += zone.GetCurrentBookCount();
        }

        if (totalBooks == 6) // If all 6 books are sorted
        {
            Debug.Log("You did it!");
            winMessage.SetActive(true);
            Invoke("CloseChalkboard", 2f);
        }
    }

    void CloseChalkboard()
    {
        chalkboard.SetActive(false);
    }
}
