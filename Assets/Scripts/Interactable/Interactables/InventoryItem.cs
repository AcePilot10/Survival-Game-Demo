using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryItem : Interactable {

    public Item item;

    public override void Interact()
    {
        item.Pickup();
        Destroy(gameObject);
    }
}