using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    public List<ClothingItem> items = new List<ClothingItem>();

    // Add item to inventory
    public void AddItem(ClothingItem item)
    {
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
