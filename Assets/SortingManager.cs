using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI; // Import for UI

public class SortingManager : MonoBehaviour
{
    public int booksNeededToWin = 3; // Each zone must have 3 books
    public GameObject winScreen; // Assign in Inspector
    private Dictionary<string, List<GameObject>> booksInZones = new Dictionary<string, List<GameObject>>();
    private bool gameOver = false;

    void Start()
    {
        booksInZones["LeftZone"] = new List<GameObject>();
        booksInZones["RightZone"] = new List<GameObject>();

        if (winScreen != null)
        {
            winScreen.SetActive(false); // Hide the win screen at the start
        }
    }

    public void AddBookToZone(string zone, GameObject book)
    {
        if (gameOver || !booksInZones.ContainsKey(zone)) return;

        if (!booksInZones[zone].Contains(book))
        {
            booksInZones[zone].Add(book);
        }

        Debug.Log($"✅ {book.name} added to {zone}. {zone} now has {booksInZones[zone].Count} books.");

        // Check if both zones are full
        if (booksInZones["LeftZone"].Count >= booksNeededToWin && booksInZones["RightZone"].Count >= booksNeededToWin)
        {
            gameOver = true;
            EndGame();
        }
    }

    void EndGame()
    {
        Debug.Log("🎉 GAME OVER! Both drop zones are full. You did it!");

        // Show the "You Did It!" screen
        if (winScreen != null)
        {
            winScreen.SetActive(true);
        }

        // Stop all books from moving
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

        // Optional: Pause game
        Time.timeScale = 0;
    }
}
