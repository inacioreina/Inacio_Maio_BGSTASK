using System.Collections.Generic;
using UnityEngine;

public class ClothesManager : MonoBehaviour
{
    public SpriteRenderer spriteRenderer;
    List<Sprite> _lastDirectionSprites;

    public InventoryManager inventoryManager;
    public InventoryManager shopInventoryManager;

    public ClothingItem currentlyEquippedItem;

    public float frameRate;
    float _idleTime;

    Vector2 _direction;
    Vector2 _lastDirection;

    private void Awake()
    {
        if (currentlyEquippedItem)
        {
            inventoryManager.AddItem(currentlyEquippedItem);
        }
    }

    //private void Update() 
    //{
    //    EquipItemFirstFrame();
    //}

    private void Start()
    {
        EquipItemFirstFrame();
    }

    public void SetSprite()
    {
        if (currentlyEquippedItem)
        {
            List<Sprite> directionSprites = SetDirectionSprites();

            if (directionSprites != null)
            {

                float playTime = Time.time - _idleTime; //time since we started walking
                int totalFrames = (int)(playTime * frameRate); //total frames since we started  
                int frame = totalFrames % directionSprites.Count; //current frame we are on

                spriteRenderer.sprite = directionSprites[frame];

                //Save the last direction sprites so that we know which sprite to reset to when the player stops walking
                //_lastDirectionSprites = directionSprites;
                _lastDirection = _direction;

            }
            else
            {   
                EquipItemFirstFrame();
                _idleTime = Time.time;
            }
        }
    }

    //Flip the sprite depending on which direction the player is moving based on the X axis
    public void FlipSprite()
    {
        if (!spriteRenderer.flipX && _direction.x < 0)
        {
            spriteRenderer.flipX = true;
        }
        else if (spriteRenderer.flipX && _direction.x > 0)
        {
            spriteRenderer.flipX = false;
        }
    }

    // This function sets the direction sprites based on the value of the direction vector and returns the corresponding sprites.
    List<Sprite> SetDirectionSprites()
    {
        List<Sprite> sprites = null;

        if (_direction.y > 0)
        {
            sprites = currentlyEquippedItem.NorthSprites;
        }
        else if (_direction.y < 0)
        {
            sprites = currentlyEquippedItem.SouthSprites;
        }
        else if (Mathf.Abs(_direction.x) > 0)
        {
            sprites = currentlyEquippedItem.EastSprites;
        }

        return sprites;
    }

    public void UpdateDir(Vector2 dir)
    {
        _direction = dir;
    }

    public void EquipItemFirstFrame()
    {
        if (currentlyEquippedItem)
        {
            if (_lastDirection.y > 0)
            {
                spriteRenderer.sprite = currentlyEquippedItem.NorthSprites[0];
            }
            else if (_lastDirection.y < 0)
            {
                spriteRenderer.sprite = currentlyEquippedItem.SouthSprites[0];
            }
            else if (Mathf.Abs(_lastDirection.x) > 0)
            {
                spriteRenderer.sprite = currentlyEquippedItem.EastSprites[0];
            }
            else if (_lastDirection == Vector2.zero)
            {
                spriteRenderer.sprite = currentlyEquippedItem.SouthSprites[0];
            }
        }
    }

    public void EquipItem(ClothingItem item)
    {
        if (currentlyEquippedItem == item)
        {
            Debug.Log("Item is already equipped, unequipping...");
            currentlyEquippedItem = null;
            spriteRenderer.sprite = null;
        }
        else
        {
            currentlyEquippedItem = item;
            //spriteRenderer.sprite = currentlyEquippedItem.SouthSprites[0];

        }

        EquipItemFirstFrame();

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

