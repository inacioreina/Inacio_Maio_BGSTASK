using System;
using System.Collections.Generic;
using UnityEngine;

public class ClothesManager : MonoBehaviour
{
    public SpriteRenderer SpriteRenderer;
    List<Sprite> lastDirectionSprites;

    public ClothingItem currentlyEquippedItem;

    public float FrameRate; 
    float idleTime;

    Vector2 direction;

    private void Start() 
    {
        //Set the sprite to the first sprite in the list facing south by default so the playere does not spawn in naked
        SpriteRenderer.sprite = currentlyEquippedItem.SouthSprites[0];
        if (currentlyEquippedItem.ModulateColour)
        {
            SpriteRenderer.color = currentlyEquippedItem.Colour;
        }
        
    }

    public void SetSprite()
    {
        List<Sprite> directionSprites = SetDirectionSprites();

        if(directionSprites != null)
        {
            
            float playTime = Time.time - idleTime; //time since we started walking
            int totalFrames = (int)(playTime * FrameRate); //total frames since we started  
            int frame = totalFrames % directionSprites.Count; //current frame we are on

            SpriteRenderer.sprite = directionSprites[frame];

            //Save the last direction sprites so that we know which sprite to reset to when the player stops walking
            lastDirectionSprites = directionSprites;
            
        }
        else
        {
            if (lastDirectionSprites != null)
            {
                //we are not walking
                //Debug.Log("we are not walking");
                //Reset the sprite to the first sprite when the player stops walking so it doesn't stop mid animation
                SpriteRenderer.sprite = lastDirectionSprites[0];
                idleTime = Time.time;
            }
        }
    }

    //Flip the sprite depending on which direction the player is moving based on the X axis
    public void FlipSprite()
    {
        if (!SpriteRenderer.flipX && direction.x < 0)
        {
            SpriteRenderer.flipX = true;
        }
        else if (SpriteRenderer.flipX && direction.x > 0)
        {
            SpriteRenderer.flipX = false;
        }
    }

    // This function sets the direction sprites based on the value of the direction vector and returns the corresponding sprites.
    List<Sprite> SetDirectionSprites()
    {
        List<Sprite> sprites = null;

        if(direction.y > 0)
        {
            sprites = currentlyEquippedItem.NorthSprites;
        }
        else if (direction.y < 0)
        {
            sprites = currentlyEquippedItem.SouthSprites;
        }
        else if (Mathf.Abs(direction.x) > 0)
        {
            sprites = currentlyEquippedItem.EastSprites;
        }

        return sprites;
    }

    public void UpdateDir(Vector2 dir)
    {
        direction = dir;
    }
}

