using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public bool IsToggledWithInput = true;

    public InventorySlot[] inventorySlots;

    public InventoryManager inventoryManager;

    public TextMeshProUGUI goldText;

    public GameObject UI_Inventory;
    public Transform UISlotsParent;
    void Start()
    {
        inventorySlots = UISlotsParent.GetComponentsInChildren<InventorySlot>();
        UpdateUI();
    }

    public void UpdateUI()
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

        if (goldText)
        {
            goldText.text = "Gold: " + inventoryManager.gold;
        }
    }
    void Update()
    {
        if (Input.GetButtonDown("Inventory") && IsToggledWithInput)
        {
            ToggleUI();
        }
    }

    public void ToggleUI()
    {
        UI_Inventory.SetActive(!UI_Inventory.activeInHierarchy);
    }

    public void SetUIActive(bool active)
    {
        UI_Inventory.SetActive(active);
    }
}

