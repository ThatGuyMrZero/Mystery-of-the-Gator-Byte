using UnityEngine;

public class DropZone : MonoBehaviour
{
    [SerializeField] public string requiredCategory;
    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log($"📌 {gameObject.name}: Something entered! Object = {other.gameObject.name}");

        if (other.CompareTag("Book"))
        {
            Debug.Log($"✅ {other.gameObject.name} entered {gameObject.name}");

            SortingManager sortingManager = Object.FindFirstObjectByType<SortingManager>();
            if (sortingManager != null)
            {
                sortingManager.AddBookToZone(gameObject.name, other.gameObject);
            }
            else
            {
                Debug.LogError("❌ SortingManager not found!");
            }
        }
        else
        {
            Debug.Log($"⚠️ {other.gameObject.name} is NOT a book, ignoring.");
        }
    }
}
