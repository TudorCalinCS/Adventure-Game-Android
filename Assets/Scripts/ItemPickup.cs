
using UnityEngine;

public class ItemPickup : Interactable
{

    public Item item;
    public override void Interact()
    {
        base.Interact();

        Pickup();
    }
    void Pickup()
    {
        Debug.Log("Picking up"+item.name);
        //Inventory.instance.AddFunction(item);
        Inventory inv = FindObjectOfType<Inventory>();
        bool waspickedup=inv.AddFunction(item);
        if(waspickedup)
        Destroy(gameObject);
    }
}
