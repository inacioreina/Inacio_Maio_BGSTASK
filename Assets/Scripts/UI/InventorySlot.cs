using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class InventorySlot : MonoBehaviour
{
    public Image itemIcon;
    public Button button;

    public ClothesManager clothesManager;

    private void Awake() 
    {
        clothesManager = FindObjectOfType<ClothesManager>();    
    }

    internal void ClearItemFromSlot()
    {
        Debug.Log("clearing item");
    }

    internal void DisplayItemInSlot(ClothingItem clothingItem)
    {
        Debug.Log("displaying item in slot");
        ClothingItem item = clothingItem;
        itemIcon.sprite = item.Icon;
        itemIcon.gameObject.SetActive(true);

    }

    public void OnButtonClick()
    {
        Debug.Log("Button clicked");
    }
}
