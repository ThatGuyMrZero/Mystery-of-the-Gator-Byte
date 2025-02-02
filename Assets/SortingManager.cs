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

        booksInZones[zone].Add(book);

        if (booksInZones[zone].Count >= booksNeededToWin)
        {
            gameWon = true;
            StopAllBooks(zone);
            Debug.Log("Sorting complete! All books locked in place.");
        }
    }

    void StopAllBooks(string zone)
    {
        foreach (GameObject book in booksInZones[zone])
        {
            if (book != null)
            {
                book.GetComponent<DragAndDrop>().enabled = false; // Stop dragging
                book.GetComponent<Collider2D>().enabled = false; // Disable collision
                book.transform.position = new Vector3(book.transform.position.x, book.transform.position.y, 0); // Keep them in place
            }
        }
    }
}
