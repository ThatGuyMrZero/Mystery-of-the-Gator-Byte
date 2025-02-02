using UnityEngine;
using System.Collections.Generic;

public class SortingManager : MonoBehaviour
{
    public int booksNeededToWin = 3;
    private Dictionary<string, List<GameObject>> booksInZones = new Dictionary<string, List<GameObject>>();
    private bool gameWon = false;

    void Start()
    {
        booksInZones["LeftZone"] = new List<GameObject>();
        booksInZones["RightZone"] = new List<GameObject>();
    }

    public void AddBookToZone(string zone, GameObject book)
    {
        if (gameWon || !booksInZones.ContainsKey(zone)) return;

        if (!booksInZones[zone].Contains(book))
        {
            booksInZones[zone].Add(book);
            Debug.Log($"✅ Book {book.name} added to {zone}. Total books: {booksInZones[zone].Count}");
        }
        else
        {
            Debug.LogWarning($"⚠️ Book {book.name} was already in {zone}!");
        }

        if (booksInZones[zone].Count >= booksNeededToWin)
        {
            gameWon = true;
            Debug.Log("🎉 Sorting complete! All books locked in place.");
            StopAllBooks(zone);
        }
    }

    private void StopAllBooks(string zone)
    {
        Debug.Log($"🛑 Stopping books in {zone}");

        foreach (GameObject book in booksInZones[zone])
        {
            if (book != null)
            {
                DragAndDrop dragScript = book.GetComponent<DragAndDrop>();
                if (dragScript != null)
                {
                    dragScript.enabled = false;
                    Debug.Log($"🚫 Disabled dragging for {book.name}");
                }

                Collider2D collider = book.GetComponent<Collider2D>();
                if (collider != null)
                {
                    collider.enabled = false;
                    Debug.Log($"🔒 Disabled collider for {book.name}");
                }

                book.transform.position = new Vector3(book.transform.position.x, book.transform.position.y, 0);
            }
        }
    }
}
