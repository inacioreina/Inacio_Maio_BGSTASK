using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Rigidbody2D body;
    public SpriteRenderer spriteRenderer;

    public ClothesManager clothesManager;

    public List<Sprite> northSprites;
    public List<Sprite> eastSprites;
    public List<Sprite> southSprites;

    List<Sprite> _lastDirectionSprites;

    public float walkSpeed;
    public float frameRate;

    float _idleTime;

    bool _canMove = true;

    Vector2 _direction;

    void Update()
    {
        if(_canMove)
        {
            _direction = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")).normalized;
            body.velocity = _direction * walkSpeed;
            FlipSprite();
            SetSprite();
        }
        
        
        
        if(clothesManager != null)
        {
            clothesManager.UpdateDir(_direction);
            clothesManager.FlipSprite();
            clothesManager.SetSprite();
        }
        
    }

    // A function to set the sprite based on the direction of the character's movement.
    void SetSprite()
    {
        List<Sprite> directionSprites = SetDirectionSprites();

        if(directionSprites != null)
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
    void FlipSprite()
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

        if(_direction.y > 0)
        {
            sprites = northSprites;
        }
        else if (_direction.y < 0)
        {
            sprites = southSprites;
        }
        else if (Mathf.Abs(_direction.x) > 0)
        {
            sprites = eastSprites;
        }

        return sprites;
    }

    public void ToggleCanMove()
    {
        _canMove = !_canMove;
        _direction = Vector2.zero;
        body.velocity = Vector2.zero;
    }
}


