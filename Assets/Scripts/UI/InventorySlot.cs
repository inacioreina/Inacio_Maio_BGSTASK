using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventorySlot : MonoBehaviour
{
    public GameObject inventorySlotPrefab;
    public Transform inventorySlotsParent;
    public PlayerController playerController;

    internal void ClearItemFromSlot()
    {
        throw new NotImplementedException();
    }

    internal void DisplayItemInSlot(ClothingItem clothingItem)
    {
        throw new NotImplementedException();
    }

    void Start()
    {
        UpdateSlotUI();
    }                                                                                

    void UpdateSlotUI()
    {
        // Clear existing inventory slots
        foreach (Transform child in inventorySlotsParent)
        {
            Destroy(child.gameObject);
        }

        // Instantiate inventory slots for each item in the player's inventory
        foreach (ClothingItem item in playerController.inventoryManager.items)
        {
            GameObject slot = Instantiate(inventorySlotPrefab, inventorySlotsParent);
            Image slotImage = slot.GetComponent<Image>();
            if (slotImage != null)
            {
                slotImage.sprite = item.Icon;
            }
        }
    }
}
