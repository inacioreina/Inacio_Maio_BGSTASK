using System.Collections.Generic;
using UnityEngine;

public class ClothesManager : MonoBehaviour
{
    public SpriteRenderer spriteRenderer;
    public InventoryManager inventoryManager;
    public InventoryManager shopInventoryManager;
    public ClothingItem currentlyEquippedItem;
    public AnimationManager animationManager;

    private void Awake()
    {
        animationManager.spriteSheets.northSprites = currentlyEquippedItem.NorthSprites;
        animationManager.spriteSheets.eastSprites = currentlyEquippedItem.EastSprites;
        animationManager.spriteSheets.southSprites = currentlyEquippedItem.SouthSprites;
        animationManager.FirstAnimationFrame(animationManager.spriteSheets);

        if (currentlyEquippedItem)
        {
            inventoryManager.AddItem(currentlyEquippedItem);
        }

        
    }

    public void EquipItem(ClothingItem item)
    {
        if (currentlyEquippedItem == item)
        {
            //Debug.Log("Item is already equipped, unequipping...");
            currentlyEquippedItem = null;
            spriteRenderer.sprite = null;
            animationManager.spriteSheets.northSprites = null;
            animationManager.spriteSheets.eastSprites = null;
            animationManager.spriteSheets.southSprites = null;
        }
        else
        {
            currentlyEquippedItem = item;
            animationManager.spriteSheets.northSprites = currentlyEquippedItem.NorthSprites;
            animationManager.spriteSheets.eastSprites = currentlyEquippedItem.EastSprites;
            animationManager.spriteSheets.southSprites = currentlyEquippedItem.SouthSprites;
            animationManager.FirstAnimationFrame(animationManager.spriteSheets);
        }

        

    }

    public void BuyItem(ClothingItem item)
    {
        if (inventoryManager.gold > item.Price)
        {
            inventoryManager.gold -= item.Price;
            shopInventoryManager.gold += item.Price;
            inventoryManager.AddItem(item);
            shopInventoryManager.RemoveItem(item);
        }
    }

    public void SellItem(ClothingItem item)
    {

        if (shopInventoryManager.gold > item.Price)
        {

            if (currentlyEquippedItem == item)
            {
                currentlyEquippedItem = null;
                spriteRenderer.sprite = null;
            }

            inventoryManager.gold += item.Price;
            shopInventoryManager.gold -= item.Price;
            inventoryManager.RemoveItem(item);
            shopInventoryManager.AddItem(item);
        }
    }

}

