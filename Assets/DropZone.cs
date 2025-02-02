using UnityEngine;

public class DropZone : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Book"))
        {
            SortingManager sortingManager = Object.FindFirstObjectByType<SortingManager>();
            if (sortingManager == null) return;

            sortingManager.AddBookToZone(gameObject.name, other.gameObject); // Send book to SortingManager
        }
    }
}
