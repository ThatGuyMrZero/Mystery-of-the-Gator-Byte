using UnityEngine;

public class SortingManager : MonoBehaviour
{
    public int booksNeededToWin = 3;
    private int leftZoneCount = 0;
    private int rightZoneCount = 0;
    private bool gameWon = false;

    public void AddBookToZone(string zone)
    {
        if (gameWon) return; // Stop counting after game is won

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
            gameWon = true;
            Debug.Log("Sorting complete! Game Over.");
        }
    }
}
