using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Rigidbody2D body;
    public SpriteRenderer spriteRenderer;
    public ClothesManager clothesManager;
    public AnimationManager bodyAnimation;
    public AnimationManager clothesAnimation;
    public SpriteAnimations spriteSheet;
    public float walkSpeed;

    bool _canMove = true;
    Vector2 _direction;

    void Update()
    {
        if(_canMove)
        {
            _direction = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")).normalized;
            body.velocity = _direction * walkSpeed;
            bodyAnimation.UpdateDir(_direction);
            bodyAnimation.FlipSprite();
            bodyAnimation.SetSprite();
        }

        if(Input.GetButtonDown("Quit"))
        {
            Application.Quit();
        }
        
        if(clothesManager != null)
        {
            clothesAnimation.UpdateDir(_direction);
            clothesAnimation.FlipSprite();
            clothesAnimation.SetSprite();
        }
        
    }

    public void ToggleCanMove()
    {
        _canMove = !_canMove;
        _direction = Vector2.zero;
        body.velocity = Vector2.zero;
    }
}


