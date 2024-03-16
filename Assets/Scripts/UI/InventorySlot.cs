using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InventorySlot : MonoBehaviour
{

    public enum ButtonBehaviour
    {
        EquipItem,
        BuyItem,
        SellItem
    }

    [SerializeField]
    private ButtonBehaviour buttonBehaviour;

    public bool displayPrice = true;
    public Image itemIcon;
    public Button button;
    public TextMeshProUGUI priceText;



    public ClothingItem item;

    public ClothesManager clothesManager;

    PlayerController _player;

    private void Awake() 
    {
        _player = FindObjectOfType<PlayerController>();    
        clothesManager = _player.clothesManager;
    }

    internal void ClearItemFromSlot()
    {
        item = null;
        itemIcon.sprite = null;

        priceText.enabled = false;
        itemIcon.enabled = false;

    }

    internal void DisplayItemInSlot(ClothingItem clothingItem)
    {
        Debug.Log("displaying item in slot");
        item = clothingItem;

        itemIcon.sprite = item.Icon;
        itemIcon.enabled = true;

        if (displayPrice)
        {
            priceText.text = item.Price.ToString();
            priceText.enabled = true;
        }

    }

    public void OnButtonClick()
    {
        //Debug.Log("Button clicked");

        if(!item)
        {
            return;
        }

        switch (buttonBehaviour)
        {
            case ButtonBehaviour.EquipItem:
                clothesManager.EquipItem(item);
                break;
            
            case ButtonBehaviour.BuyItem:
                clothesManager.BuyItem(item);
                ClearItemFromSlot();
                break;

            case ButtonBehaviour.SellItem:
                clothesManager.SellItem(item);
                ClearItemFromSlot();
                break;
                
        }


    }
}
