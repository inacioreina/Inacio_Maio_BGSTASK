using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Rigidbody2D Body;
    public SpriteRenderer SpriteRenderer;

    public ClothesManager ClothesManager;

    public List<Sprite> NorthSprites;
    public List<Sprite> EastSprites;
    public List<Sprite> SouthSprites;

    List<Sprite> lastDirectionSprites;
    

    public float WalkSpeed;
    public float FrameRate;

    float idleTime;

    Vector2 direction;

    void Update()
    {
        direction = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")).normalized;
        ClothesManager.UpdateDir(direction);

        Body.velocity = direction * WalkSpeed;
        
        FlipSprite();
        
        SetSprite();
        

        if(ClothesManager != null)
        {
            ClothesManager.FlipSprite();
            ClothesManager.SetSprite();
        }
        
    }

    // A function to set the sprite based on the direction of the character's movement.
    void SetSprite()
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
    void FlipSprite()
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
            sprites = NorthSprites;
        }
        else if (direction.y < 0)
        {
            sprites = SouthSprites;
        }
        else if (Mathf.Abs(direction.x) > 0)
        {
            sprites = EastSprites;
        }

        return sprites;
    }
}


