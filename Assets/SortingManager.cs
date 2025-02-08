using UnityEngine;
using System.Collections.Generic;

public class SortingManager : MonoBehaviour
{
    public int booksNeededToWin = 3;
    public GameObject winSprite; // Assign in Inspector
    public GameObject backgroundBooksGroup; // Assign in Inspector (if using group)
    private Dictionary<string, List<GameObject>> booksInZones = new Dictionary<string, List<GameObject>>();
    private bool gameOver = false;

    void Start()
    {
        booksInZones["LeftZone"] = new List<GameObject>();
        booksInZones["RightZone"] = new List<GameObject>();

        if (winSprite != null)
        {
            winSprite.SetActive(false); // Hide the win sprite at the start
        }
    }

    public void AddBookToZone(string zone, GameObject book)
    {
        if (gameOver || !booksInZones.ContainsKey(zone)) return;

        if (!booksInZones[zone].Contains(book))
        {
            booksInZones[zone].Add(book);
        }

        Debug.Log($"✅ {book.name} added to {zone}. Counts: LeftZone = {booksInZones["LeftZone"].Count}, RightZone = {booksInZones["RightZone"].Count}");

        // Only end the game if BOTH zones have exactly 3 books
        if (booksInZones["LeftZone"].Count == booksNeededToWin && booksInZones["RightZone"].Count == booksNeededToWin)
        {
            gameOver = true;
            EndGame();
        }
    }

    void EndGame()
    {
        Debug.Log("🎉 GAME OVER! Both drop zones are full. You did it!");

        // Show the "You Did It!" sprite
        if (winSprite != null)
        {
            winSprite.SetActive(true);
            Debug.Log("✅ WinSprite is now visible!");
        }
        else
        {
            Debug.LogError("❌ WinSprite is NOT assigned in the Inspector!");
        }

        // Hide all background books
        HideBackgroundBooks();

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

    void HideBackgroundBooks()
    {
        if (backgroundBooksGroup != null)
        {
            backgroundBooksGroup.SetActive(false);
            Debug.Log("📚 Background books are now hidden!");
        }
        else
        {
            Debug.LogWarning("⚠️ No background book group assigned! Hiding by tag instead...");

            GameObject[] backgroundBooks = GameObject.FindGameObjectsWithTag("BackgroundBook");
            foreach (GameObject book in backgroundBooks)
            {
                book.SetActive(false);
            }
        }
    }
}
