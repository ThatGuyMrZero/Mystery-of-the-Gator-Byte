using UnityEngine;

public class DropZone : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Book"))
        {
            SortingManager sortingManager = FindObjectOfType<SortingManager>();
            sortingManager.AddBookToZone(gameObject.name); // Add book to the correct zone
            other.GetComponent<DragAndDrop>().enabled = false; // Disable dragging after placement
            other.transform.position = transform.position; // Snap book into place
        }
    }
}
