using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public GameObject chalkboard;
    public GameObject winMessage;

    private DropZone[] dropZones;

    void Awake()
    {
        instance = this;
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

        if (totalBooks == 6)
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
