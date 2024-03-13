using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    public List<ClothingItem> items = new List<ClothingItem>();

    public int gold = 500;

    public int inventoryLimit = 20;

    // Add item to inventory
    public void AddItem(ClothingItem item)
    {
        if(items.Count >= inventoryLimit)
        {
            return;
        }
        
        items.Add(item);
    }

    // Remove item from inventory
    public void RemoveItem(ClothingItem item)
    {
        items.Remove(item);
    }
}
