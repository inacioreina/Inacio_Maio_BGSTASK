using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public struct SpriteAnimations
{
    public List<Sprite> northSprites;
    public List<Sprite> eastSprites;
    public List<Sprite> southSprites;
}

public class AnimationManager : MonoBehaviour
{
    public SpriteRenderer spriteRenderer;
    public float frameRate;
    public Rigidbody2D rb;
    public SpriteAnimations spriteSheets;

    float _idleTime;

    Vector2 _direction;
    Vector2 _lastDirection = Vector2.zero;

    private void FixedUpdate() 
    {
        UpdateDir();
        //Debug.Log(_direction);
        FlipSprite();
        SetSprite();
    }

    public void UpdateDir()
    {
        _direction = rb.velocity.normalized;
    }

    private void Start()
    {
        FirstAnimationFrame(spriteSheets);
        _idleTime = Time.time;
    }

    public void SetSprite()
    {
        List<Sprite> directionSprites = SetDirectionSprites(spriteSheets);

        if (directionSprites != null)
        {
            float playTime = Time.time - _idleTime; //time since we started walking
            int totalFrames = (int)(playTime * frameRate); //total frames since we started  
            int frame = totalFrames % directionSprites.Count; //current frame we are on

            spriteRenderer.sprite = directionSprites[frame];

            //Save the last direction sprites so that we know which sprite to reset to when the player stops walking
            //_lastDirectionSprites = directionSprites;
            _lastDirection = _direction;

            //Debug.Log("we are walking");
        }
        else
        {
            //we are not walking
            //Debug.Log("we are not walking");
            //Reset the sprite to the first sprite when the player stops walking so it doesn't stop mid animation
            FirstAnimationFrame(spriteSheets);
            _idleTime = Time.time;
        }
    }

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

    List<Sprite> SetDirectionSprites(SpriteAnimations spriteSheet)
    {
        List<Sprite> sprites = null;

        if (_direction == Vector2.zero)
        {
            sprites = null;
            Debug.Log("null");
        }
        else if (_direction.y > 0)
        {
            sprites = spriteSheet.northSprites;
            Debug.Log("y > 0");
        }
        else if (_direction.y < 0)
        {
            sprites = spriteSheet.southSprites;
            Debug.Log("y < 0");
        }
        else if (Mathf.Abs(_direction.x) > .9f)
        {
            Debug.Log("VALUE: " + Mathf.Abs(_direction.x));
            sprites = spriteSheet.eastSprites;
            Debug.Log("x > 0");
        }

        return sprites;
    }

    public void FirstAnimationFrame(SpriteAnimations spriteSheet)
    {
        if (_lastDirection.y > 0)
        {
            spriteRenderer.sprite = spriteSheet.northSprites[0];
        }
        else if (_lastDirection.y < 0)
        {
            spriteRenderer.sprite = spriteSheet.southSprites[0];
        }
        else if (Mathf.Abs(_lastDirection.x) > 0)
        {
            spriteRenderer.sprite = spriteSheet.eastSprites[0];
        }
        else if (_lastDirection == Vector2.zero)
        {
            spriteRenderer.sprite = spriteSheet.southSprites[0];
        }
    }

}
