using UnityEngine;

public class BackpackClick : MonoBehaviour
{
    public InventoryUI inventoryUI;

    void OnMouseDown()
    {
        inventoryUI.ToggleInventory();
    }
}
