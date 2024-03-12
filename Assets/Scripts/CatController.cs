using UnityEngine;

public class CatController : PlayerInteractable
{
    // Start is called before the first frame update
    public override void Interact()
    {
        base.Interact();
        Debug.Log("You pet the cat.");
    }
}
