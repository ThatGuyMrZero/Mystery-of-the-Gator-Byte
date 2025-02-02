using UnityEngine;
using System.Collections.Generic;

public class SortingManager : MonoBehaviour
{
    public int booksNeededToWin = 3;
    private Dictionary<string, List<GameObject>> booksInZones = new Dictionary<string, List<GameObject>>();
    private bool gameOver = false;

    void Start()
    {
        booksInZones["LeftZone"] = new List<GameObject>();
        booksInZones["RightZone"] = new List<GameObject>();
    }

    public void AddBookToZone(string zone, GameObject book)
    {
        if (gameOver || !booksInZones.ContainsKey(zone)) return;

        if (!booksInZones[zone].Contains(book))
        {
            booksInZones[zone].Add(book);
        }

        if (booksInZones[zone].Count >= booksNeededToWin)
        {
            gameOver = true;
            EndGame();
        }
    }

    void EndGame()
    {
        Debug.Log("🎉 GAME OVER! Books sorted correctly.");

        // Disable all books' movement
        foreach (var zone in booksInZones)
        {
            foreach (GameObject book in zone.Value)
            {
                if (book != null)
                {
                    book.GetComponent<DragAndDrop>().enabled = false;
                    book.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;
                }
            }
        }

        // Optional: Stop time
        Time.timeScale = 0;
    }
}
