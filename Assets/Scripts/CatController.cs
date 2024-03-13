using System.Collections;
using UnityEngine;

public class CatController : PlayerInteractable
{
    public InventoryManager playerInventoryManager;
    public Animator animator;
    public SpriteRenderer spriteRenderer;
    
    private bool _isCoroutineRunning = false;
    

    // Start is called before the first frame update
    public override void Interact()
    {
        base.Interact();
        Debug.Log("You pet the cat.");


        if(!_isCoroutineRunning)
        {
            StartCoroutine(StartAndStopAnimation());
        }

        if(playerInventoryManager)
        {
            playerInventoryManager.gold += 33;
        }

    }

    //Coroutine that disables animator and spriterenderer

    private IEnumerator StartAndStopAnimation()
    {
        _isCoroutineRunning = true;

        animator.Play("Love");
        animator.enabled = true;
        spriteRenderer.enabled = true;

        yield return new WaitForSeconds(2);

        animator.enabled = false;
        spriteRenderer.enabled = false;

        _isCoroutineRunning = false;
    }

}
