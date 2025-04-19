using UnityEngine;

public class SortingManager : MonoBehaviour
{
    public int booksNeededToWin = 3;
    public GameObject winSprite;
    public GameObject backgroundBooksGroup;

    private bool gameOver = false;

    public void CheckGameEnd()
    {
        if (gameOver) return;

        int correctLeft = 0;
        int correctRight = 0;

        GameObject[] allBooks = GameObject.FindGameObjectsWithTag("Book");

        foreach (GameObject book in allBooks)
        {
            DragAndDrop bookScript = book.GetComponent<DragAndDrop>();
            if (bookScript == null || bookScript.currentDropZone == null) continue;

            DropZone dropZone = bookScript.currentDropZone.GetComponent<DropZone>();
            if (dropZone == null) continue;

            if (dropZone.requiredCategory == bookScript.category)
            {
                if (dropZone.gameObject.name == "LeftZone") correctLeft++;
                else if (dropZone.gameObject.name == "RightZone") correctRight++;
            }
        }

        Debug.Log($"✅ Correct Left: {correctLeft}, Correct Right: {correctRight}");

        if (correctLeft == booksNeededToWin && correctRight == booksNeededToWin)
        {
            gameOver = true;
            EndGame();
        }
    }

    void EndGame()
    {
        Debug.Log("🎉 GAME OVER! Both drop zones are correctly filled!");

        if (winSprite != null)
        {
            winSprite.SetActive(true);
        }

        if (backgroundBooksGroup != null)
        {
            backgroundBooksGroup.SetActive(false);
        }

        GameObject[] allBooks = GameObject.FindGameObjectsWithTag("Book");
        foreach (GameObject book in allBooks)
        {
            DragAndDrop drag = book.GetComponent<DragAndDrop>();
            if (drag != null)
            {
                drag.enabled = false;
            }
        }
    }
}
