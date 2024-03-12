using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    public List<ClothingItem> items = new List<ClothingItem>();

    public int inventoryLimit = 32;

    // Add item to inventory
    public void AddItem(ClothingItem item)
    {
        if(items.Count >= inventoryLimit)
        {
            return;
        }
        
        items.Add(item);
        // TODO: Update the UI here to reflect the addition of the item
    }

    // Remove item from inventory
    public void RemoveItem(ClothingItem item)
    {
        items.Remove(item);
        // TODO: Update the UI here to reflect the removal of the item
    }
}
