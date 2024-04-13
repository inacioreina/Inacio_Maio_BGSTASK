using UnityEngine;

public class ShopKeeperBehaviour : PlayerInteractable
{
    public UIManager UIStoreManager;
    public UIManager UIPlayerManager;
    public UIManager UIStorePlayerManager;
    public bool ShopUIOpen = false;

    public override void Interact()
    {
        //Debug.Log("help");
        base.Interact();
        
        if(UIStoreManager)
        {
            ShopUIOpen = !ShopUIOpen;
            UIStorePlayerManager.UpdateUI();
            //Turn off the player inventory incase it is open already
            UIPlayerManager.SetUIActive(false);

            UIStoreManager.ToggleUI();
            UIStorePlayerManager.ToggleUI();
            _player.GetComponent<PlayerController>().ToggleCanMove();
        }
    }
}
