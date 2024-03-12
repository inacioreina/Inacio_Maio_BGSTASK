using UnityEngine;

public class PlayerInteractable : MonoBehaviour
{
    public float interactRange = 2.3f;
    GameObject _player;

    GameObject _displayInteractionKeySprite;

    public Sprite spriteUI;

    //public string imagePath = "Sprites/UI/UI_E";
    public float xOffset = 1.3005007f;
    public float yOffset = 1.30000038f;

    private void Awake()
    {
        //Assign the player to the player variable on Awake
        _player = GameObject.FindGameObjectWithTag("Player");
    }

    internal void Start() 
    {
        // I tried both methods of loading from the sprite sheet and just using the one sprite but both of them were not working so I am not going to waste anymore time with this.

        // Load the sprite sheet and get the sprite at index 20
        //Sprite[] sprites = Resources.LoadAll<Sprite>("Sprites/UI/Keyboard Letters and Symbols.png");
        
        //if (sprites == null)
        //{
        //    Debug.LogError("Failed to load sprite or sprite index out of range.");
        //    return;
        //}
        //
        //Sprite sprite = sprites[0];

        //if (spriteUI != null)
        //{
        //    GetComponent<SpriteRenderer>().sprite = spriteUI;
        //}

        _displayInteractionKeySprite = new GameObject("DisplayInteractionKeySprite");
        _displayInteractionKeySprite.SetActive(false);
        _displayInteractionKeySprite.transform.SetParent(transform);

        SpriteRenderer spriteRenderer = _displayInteractionKeySprite.AddComponent<SpriteRenderer>();
        spriteRenderer.sortingOrder = 1;

        spriteRenderer.sprite = spriteUI;

        Vector3 pos = transform.position + new Vector3(xOffset, yOffset, 0f);
        spriteRenderer.transform.position = pos;
    }

    internal void Update()
    {
        if (_player)
        {
            if (_player && Vector2.Distance(_player.transform.position, transform.position) < interactRange)
            {
                _displayInteractionKeySprite.SetActive(true);

                if (Input.GetKeyDown(KeyCode.E) | Input.GetKeyDown(KeyCode.Mouse0))
                    {
                        Interact();
                    }
            }
            else
            {
                _displayInteractionKeySprite.SetActive(false);
            }
        }
    }

    public virtual void Interact()
    {
        Debug.Log("test");
    }
}
