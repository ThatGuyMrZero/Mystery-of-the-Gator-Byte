using UnityEngine;
using System.Collections.Generic;

public class InventoryUI : MonoBehaviour
{
    public GameObject inventoryPanel;
    public Transform itemHolder;

    // Assign prefabs in Inspector
    public GameObject libraryKeyPrefab;

    private Dictionary<string, GameObject> itemPrefabLookup;

    void Start()
    {
        itemPrefabLookup = new Dictionary<string, GameObject>
        {
            { "Library Key", libraryKeyPrefab },
        };
    }

    public void ToggleInventory()
    {
        bool isActive = inventoryPanel.activeSelf;
        inventoryPanel.SetActive(!isActive);

        if (!isActive)
        {
            ShowItems();
        }
    }

    void ShowItems()
    {
        foreach (Transform child in itemHolder)
        {
            Destroy(child.gameObject);
        }

        foreach (string item in InventoryManager.Instance.items)
        {
            if (itemPrefabLookup.ContainsKey(item))
            {
                GameObject itemPrefab = itemPrefabLookup[item];
                GameObject newItem = Instantiate(itemPrefab, itemHolder);
                newItem.transform.localPosition = new Vector3(0, -itemHolder.childCount * 1.5f, 0);
            }
            else
            {
                Debug.LogWarning($"No sprite prefab found for item: {item}");
            }
        }
    }
}
