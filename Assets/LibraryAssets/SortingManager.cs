using UnityEngine;
using System.Collections.Generic;

public class SortingManager : MonoBehaviour
{
    public int booksNeededToWin = 3;
    public GameObject winSprite;
    public GameObject backgroundBooksGroup;

    private Dictionary<string, List<GameObject>> booksInZones = new Dictionary<string, List<GameObject>>();
    private bool gameOver = false;

    void Start()
    {
        booksInZones["LeftZone"] = new List<GameObject>();
        booksInZones["RightZone"] = new List<GameObject>();

        if (winSprite != null)
        {
            winSprite.SetActive(false);
        }
    }

    public void AddBookToZone(string zone, GameObject book)
    {
        if (gameOver || !booksInZones.ContainsKey(zone)) return;

        DragAndDrop bookScript = book.GetComponent<DragAndDrop>();
        if (bookScript == null || bookScript.currentDropZone == null) return;

        DropZone dropZone = bookScript.currentDropZone.GetComponent<DropZone>();
        if (dropZone == null) return;

        // Only add book if it's in the correct drop zone
        if (dropZone.requiredCategory == bookScript.category)
        {
            if (!booksInZones[zone].Contains(book))
            {
                booksInZones[zone].Add(book);
            }

            Debug.Log($"✅ {book.name} correctly placed in {zone}. Now: LeftZone={booksInZones["LeftZone"].Count}, RightZone={booksInZones["RightZone"].Count}");

            CheckGameEnd();
        }
        else
        {
            Debug.Log($"❌ {book.name} does NOT belong in {zone}, ignoring.");
        }
    }



    public void RemoveBookFromZone(string zone, GameObject book)
    {
        if (!booksInZones.ContainsKey(zone)) return;

        if (booksInZones[zone].Contains(book))
        {
            booksInZones[zone].Remove(book);
        }

        Debug.Log($"❌ {book.name} removed from {zone}. Now: LeftZone={booksInZones["LeftZone"].Count}, RightZone={booksInZones["RightZone"].Count}");
    }


    void CheckGameEnd()
    {
        int correctLeft = 0;
        int correctRight = 0;

        Debug.Log("Checking game end...");

        foreach (GameObject book in booksInZones["LeftZone"])
        {
            DragAndDrop bookScript = book.GetComponent<DragAndDrop>();

            if (bookScript != null && bookScript.currentDropZone != null)
            {
                DropZone dropZone = bookScript.currentDropZone.GetComponent<DropZone>();

                if (dropZone != null && dropZone.requiredCategory == bookScript.category)
                {
                    correctLeft++;
                }
            }
        }

        foreach (GameObject book in booksInZones["RightZone"])
        {
            DragAndDrop bookScript = book.GetComponent<DragAndDrop>();

            if (bookScript != null && bookScript.currentDropZone != null)
            {
                DropZone dropZone = bookScript.currentDropZone.GetComponent<DropZone>();

                if (dropZone != null && dropZone.requiredCategory == bookScript.category)
                {
                    correctRight++;
                }
            }
        }

        Debug.Log($"✅ LeftZone Correct Count: {correctLeft}, RightZone Correct Count: {correctRight}");

        if (correctLeft == booksNeededToWin && correctRight == booksNeededToWin)
        {
            Debug.Log("🎉 All books are correctly placed! Ending game...");
            gameOver = true;
            EndGame();
        }
    }


    void EndGame()
    {
        Debug.Log("🎉 GAME OVER! Both drop zones are correctly filled!");

        // Make sure the win message appears
        if (winSprite != null)
        {
            winSprite.SetActive(true);
            Debug.Log("✅ WinSprite is now visible!");
        }
        else
        {
            Debug.LogError("❌ WinSprite is NOT assigned in the Inspector!");
        }

        // ✅ Hide background books
        HideBackgroundBooks();

        // Disable dragging after win
        foreach (var zone in booksInZones)
        {
            foreach (GameObject book in zone.Value)
            {
                if (book != null)
                {
                    book.GetComponent<DragAndDrop>().enabled = false;
                }
            }
        }
    }




    void HideBackgroundBooks()
    {
        if (backgroundBooksGroup != null)
        {
            backgroundBooksGroup.SetActive(false);
        }
    }
}
