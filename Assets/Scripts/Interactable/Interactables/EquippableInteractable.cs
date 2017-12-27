using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquippableInteractable : InventoryItem {

    public override void Interact()
    {
        PlayerEquipment.instance.Equip(item as Equipment);
        Destroy(gameObject);
    }
}