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

        if (!booksInZones[zone].Contains(book))
        {
            booksInZones[zone].Add(book);
        }

        CheckGameEnd();
    }

    public void RemoveBookFromZone(string zone, GameObject book)
    {
        if (!booksInZones.ContainsKey(zone)) return;

        if (booksInZones[zone].Contains(book))
        {
            booksInZones[zone].Remove(book);
        }
    }

    void CheckGameEnd()
    {
        if (booksInZones["LeftZone"].Count == booksNeededToWin && booksInZones["RightZone"].Count == booksNeededToWin)
        {
            gameOver = true;
            EndGame();
        }
    }

    void EndGame()
    {
        if (winSprite != null)
        {
            winSprite.SetActive(true);
        }

        HideBackgroundBooks();

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
