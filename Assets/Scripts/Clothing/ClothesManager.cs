using System.Collections.Generic;
using UnityEngine;

public class ClothesManager : MonoBehaviour
{
    public SpriteRenderer spriteRenderer;
    List<Sprite> _lastDirectionSprites;

    public ClothingItem currentlyEquippedItem;

    public float frameRate;
    float _idleTime;

    Vector2 _direction;

    private void Start()
    {
        EquipItemFirstFrame();
    }

    public void SetSprite()
    {
        List<Sprite> directionSprites = SetDirectionSprites();

        if (directionSprites != null)
        {

            float playTime = Time.time - _idleTime; //time since we started walking
            int totalFrames = (int)(playTime * frameRate); //total frames since we started  
            int frame = totalFrames % directionSprites.Count; //current frame we are on

            spriteRenderer.sprite = directionSprites[frame];

            //Save the last direction sprites so that we know which sprite to reset to when the player stops walking
            _lastDirectionSprites = directionSprites;

        }
        else
        {
            if (_lastDirectionSprites != null)
            {
                //we are not walking
                //Debug.Log("we are not walking");
                //Reset the sprite to the first sprite when the player stops walking so it doesn't stop mid animation
                spriteRenderer.sprite = _lastDirectionSprites[0];
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
            spriteRenderer.sprite = currentlyEquippedItem.SouthSprites[0];
            if (currentlyEquippedItem.ModulateColour)
            {
                spriteRenderer.color = currentlyEquippedItem.Colour;
            }
        }
    }

    public void EquipItem(ClothingItem item)
    {
        if (currentlyEquippedItem == item)
        {
            currentlyEquippedItem = null;
            spriteRenderer.sprite = null;
            return;
        }

        currentlyEquippedItem = item;
        EquipItemFirstFrame();
    }

}

