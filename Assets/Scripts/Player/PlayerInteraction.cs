using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

public class PlayerInteraction : MonoBehaviour
{
    public float InteractRange = 2f;
    public UnityEvent OnInteract;
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E)) 
        {
            //Debug.Log(LayerMask.GetMask("Interactables") Layer mask int for the interactables is 8 so I will be using that instead of using get mask everytime
            // TODO: USE LAYER MASK
            Collider2D collider = Physics2D.OverlapBox(transform.position, new Vector2(InteractRange, InteractRange), 0, 8);

            if (collider != null)
            {
                //Debug.Log(collider.name);
                OnInteract.Invoke();
            }
            
        }
        
    }
}
