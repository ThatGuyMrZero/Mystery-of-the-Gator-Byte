using UnityEngine;
using System.Collections.Generic;

public class InventoryUI : MonoBehaviour
{
    public GameObject inventoryPanel;
    public Transform itemHolder;

    // Item prefab references
    public GameObject libraryKeyPrefab;
    public GameObject crumpledNapkinPrefab;
    public GameObject iouSlipPrefab;
    public GameObject rippedClothPrefab;
    public GameObject keyPrefab;

    private Dictionary<string, GameObject> itemPrefabLookup;

    private bool inventoryVisible = false;

    void Start()
    {
        itemPrefabLookup = new Dictionary<string, GameObject>
        {
            { "Library Key", libraryKeyPrefab },
            { "Crumpled Napkin", crumpledNapkinPrefab },
            { "IOU Slip", iouSlipPrefab },
            { "Ripped Cloth", rippedClothPrefab },
            { "Key", keyPrefab },

        };

        inventoryPanel.SetActive(false);
    }

    public void ToggleInventory()
    {
        inventoryVisible = !inventoryVisible;
        inventoryPanel.SetActive(inventoryVisible);

        if (inventoryVisible)
        {
            RefreshInventoryUI();
        }
    }

    void RefreshInventoryUI()
    {
        // 🔄 Clear all previously spawned sprite children
        foreach (Transform child in itemHolder)
        {
            Destroy(child.gameObject);
        }

        // 🆕 Instantiate sprites from inventory
        int i = 0;
        foreach (string item in InventoryManager.Instance.items)
        {
            Debug.Log($"🧾 Inventory contains: '{item}'");
            if (itemPrefabLookup.ContainsKey(item))
            {
                GameObject newItem = Instantiate(itemPrefabLookup[item], itemHolder);

                // Add positioning based on index
                if (i == 0)
                    newItem.transform.localPosition = new Vector3(-2, -i * 1.5f, 3);
                else if (i == 1)
                    newItem.transform.localPosition = new Vector3(0, -i * 1.5f, 0);
                else if (i == 2)
                    newItem.transform.localPosition = new Vector3(0, -i * 1.5f, 2);
                else if (i == 3)
                    newItem.transform.localPosition = new Vector3(1, -i * 1.5f, 0);
                else if (i == 4)
                    newItem.transform.localPosition = new Vector3(-1, -i * 1.5f, 2);
                else
                    newItem.transform.localPosition = new Vector3(2, -i * 1.5f, 0); // Fallback for extras

                i++;
            }
            else
            {
                Debug.LogWarning($"No prefab found for item '{item}'");
            }
        }
    }
}
