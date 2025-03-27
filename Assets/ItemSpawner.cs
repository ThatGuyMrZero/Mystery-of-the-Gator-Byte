using UnityEngine;
using UnityEngine.EventSystems;

public class ItemSpawner : MonoBehaviour 
{

    public GameObject itemPrefab;
    private Vector2 spawnPosition;
    private Transform parentContainer;


    void Start()
    {
        spawnPosition = GetComponent<RectTransform>().anchoredPosition;
        parentContainer = transform.parent;
        SpawnNewItem();
    }

    public void SpawnNewItem()
    {
        GameObject newItem = Instantiate(itemPrefab, parentContainer);
        newItem.GetComponent<RectTransform>().anchoredPosition = spawnPosition;
        newItem.GetComponent<ItemStack>().SetSpawner(this);
        newItem.transform.SetParent(parentContainer, false);
        Debug.Log($"Spawned new {newItem.name} at original spawn position.");
    }

}
