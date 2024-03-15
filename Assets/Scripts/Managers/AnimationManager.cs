using System;
using System.Collections;
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

    public SpriteAnimations spriteSheets;

    float _idleTime;

    PlayerController player;

    Vector2 _direction;
    Vector2 _lastDirection = Vector2.zero;

    private void Awake() 
    {
        player = FindObjectOfType<PlayerController>();
    }

    private void Update() 
    {
        UpdateDir(player._direction);
        FlipSprite();
        SetSprite();
    }

    public void UpdateDir(Vector2 dir)
    {
        _direction = dir;
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

        if (_direction.y > 0)
        {
            sprites = spriteSheet.northSprites;
        }
        else if (_direction.y < 0)
        {
            sprites = spriteSheet.southSprites;
        }
        else if (Mathf.Abs(_direction.x) > 0)
        {
            sprites = spriteSheet.eastSprites;
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
