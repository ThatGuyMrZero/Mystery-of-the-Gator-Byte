using UnityEngine;
using System.Collections.Generic;

public class DormKeyRevealer : MonoBehaviour
{
    public GameObject keyObject;
    public GameObject noteObject;


    private List<string> requiredItems = new List<string>
    {
        "Library Key",
        "Crumpled Napkin",
        "IOU Slip",
        "Ripped Cloth"
    };

    void Start()
    {
        if (keyObject == null)
        {
            Debug.LogWarning("DormKeyRevealer: No key object assigned!");
            return;
        }

        keyObject.SetActive(false); // Hide by default
        noteObject.SetActive(false);

        // Check if all required items are in the inventory
        bool hasAllItems = true;
        foreach (string item in requiredItems)
        {
            if (!InventoryManager.Instance.items.Contains(item))
            {
                hasAllItems = false;
                break;
            }
        }

        if (hasAllItems)
        {
            keyObject.SetActive(true);
            noteObject.SetActive(true);
            Debug.Log("Dorm key auto-revealed at scene start!");
        }
    }
}
