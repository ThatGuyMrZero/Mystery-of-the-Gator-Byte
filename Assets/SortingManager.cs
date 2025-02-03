using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI; // Import for UI

public class SortingManager : MonoBehaviour
{
    public int booksNeededToWin = 3;
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

        if (booksInZones[zone].Count >= booksNeededToWin)
        {
            gameOver = true;
            EndGame();
        }
    }

    void EndGame()
    {
        Debug.Log("🎉 GAME OVER! Books sorted correctly.");

        if (winScreen != null)
        {
            Debug.Log("✅ WinScreen is assigned. Activating now...");
            winScreen.SetActive(true);
        }
        else
        {
            Debug.LogError("❌ WinScreen is NOT assigned in the Inspector!");
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

        // Optional: Pause the game
        Time.timeScale = 0;
    }

}
