using UnityEngine;
using UnityEngine.UI;

public class SortingManager : MonoBehaviour
{
    public int booksNeededToWin = 3;
    public Text winText;

    private int leftZoneCount = 0;
    private int rightZoneCount = 0;

    void Start()
    {
        winText.gameObject.SetActive(false);
    }

    public void AddBookToZone(string zone)
    {
        if (zone == "LeftZone")
            leftZoneCount++;
        else if (zone == "RightZone")
            rightZoneCount++;

        CheckWinCondition();
    }

    void CheckWinCondition()
    {
        if (leftZoneCount >= booksNeededToWin || rightZoneCount >= booksNeededToWin)
        {
            winText.gameObject.SetActive(true);
            Debug.Log("You did it!");
        }
    }
}
