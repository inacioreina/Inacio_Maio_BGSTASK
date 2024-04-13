using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Rigidbody2D body;
    public float walkSpeed;
    public ClothesManager clothesManager;

    public bool canMove = true;
    public Vector2 _direction;

    private void Awake() 
    {
        clothesManager = GetComponent<ClothesManager>();
    }

    void Update()
    {
        if(canMove)
        {
            _direction = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")).normalized;
            body.velocity = _direction * walkSpeed;
        }

        if(Input.GetButtonDown("Quit"))
        {
            Application.Quit();
        }
    }

    public void ToggleCanMove()
    {
        canMove = !canMove;
        //_direction = Vector2.zero;
        body.velocity = Vector2.zero;
    }
}


