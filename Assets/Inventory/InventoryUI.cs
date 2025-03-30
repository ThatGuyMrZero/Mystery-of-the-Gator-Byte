using UnityEngine;
using System.Collections.Generic;

public class InventoryUI : MonoBehaviour
{
    public GameObject inventoryPanel;
    public Transform itemHolder;

    // Item prefab references
    public GameObject libraryKeyPrefab;
    public GameObject crumpledNapkinPrefab;

    private Dictionary<string, GameObject> itemPrefabLookup;

    private bool inventoryVisible = false;

    void Start()
    {
        itemPrefabLookup = new Dictionary<string, GameObject>
        {
            { "Library Key", libraryKeyPrefab },
            { "Crumpled Napkin", crumpledNapkinPrefab },

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
            if (itemPrefabLookup.ContainsKey(item))
            {
                GameObject newItem = Instantiate(itemPrefabLookup[item], itemHolder);
                if (i == 0)
                { newItem.transform.localPosition = new Vector3(-2, -i * 1.5f, 3); }
                else if (i == 1)
                { newItem.transform.localPosition = new Vector3(0, -i * 1.5f, 0); }
                i++;
            }
            else
            {
                Debug.LogWarning($"No prefab found for item '{item}'");
            }
        }
    }
}
