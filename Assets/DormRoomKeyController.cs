using UnityEngine;

public class DormRoomKeyController : MonoBehaviour
{
    public GameObject keyObject; // Drag the key prefab in the Inspector

    // The 4 items needed to make the key appear
    private readonly string[] requiredItems = {
        "Library Key",
        "Crumpled Napkin",
        "Ripped Cloth",
        "IOU Slip"
    };

    void Start()
    {
        // Hide the key at the start
        if (keyObject != null)
            keyObject.SetActive(false);

        CheckForCompletion();
    }

    void CheckForCompletion()
    {
        if (InventoryManager.Instance == null) return;

        bool hasAllItems = true;
        foreach (string item in requiredItems)
        {
            if (!InventoryManager.Instance.items.Contains(item))
            {
                hasAllItems = false;
                break;
            }
        }

        if (hasAllItems && keyObject != null)
        {
            keyObject.SetActive(true); // Show the key!
            Debug.Log("🔑 All items collected! Key is now visible.");
        }
    }
}
