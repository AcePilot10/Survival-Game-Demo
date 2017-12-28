using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryItem : Interactable {

    public Item item;

    public override void Interact()
    {
        if (!Inventory.instance.IsFull())
        {
            base.Interact();
            item.Pickup();
            Destroy(gameObject);
        }
        else {
            Debug.Log("Inventory Is Full!");
        }
    }
}