using UnityEngine;

public class PlayerInteractable : MonoBehaviour
{
    public float InteractRange = 3.3f;
    GameObject player;

    private void Awake()
    {
        //Assign the player to the player variable on Awake
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) | Input.GetKeyDown(KeyCode.Mouse0))
        {
            //Debug.Log(LayerMask.GetMask("Interactable") Layer mask int for the interactables is 8 so I will be using that instead of using get mask everytime
            //Collider2D collider = Physics2D.OverlapBox(player.transform.position, new Vector2(InteractRange, InteractRange), 0, 8);

            if (!player)
            {
                player = GameObject.FindGameObjectWithTag("Player");
            }
            else if (player && Vector2.Distance(player.transform.position, transform.position) < InteractRange)
            {
                Interact();
            }
        }
    }

    public virtual void Interact()
    {
        Debug.Log("test");
    }
}
