using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public InventorySlot[] inventorySlots;

    public InventoryManager inventoryManager;

    public GameObject UI_Inventory;
    public Transform UISlotsParent;
    void Start()
    {
        inventorySlots = UISlotsParent.GetComponentsInChildren<InventorySlot>();
        UpdateUI();
    }

    void UpdateUI()
    {
        for (int i = 0; i < inventorySlots.Length; i++)
        {
            if (i < inventoryManager.items.Count)
            {
                inventorySlots[i].DisplayItemInSlot(inventoryManager.items[i]);
            }
            else
            {
                inventorySlots[i].ClearItemFromSlot();
            }
        }
    }
    void Update()
    {
        ShowUI();
    }

    void ShowUI()
    {
        if (Input.GetButtonDown("Inventory"))
        {
            UI_Inventory.SetActive(!UI_Inventory.activeInHierarchy);
        }
    }
}

