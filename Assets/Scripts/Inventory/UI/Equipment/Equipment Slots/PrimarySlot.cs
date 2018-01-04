using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrimarySlot : EquipmentSlot {

    public override void Unequip()
    {
        PlayerEquipment.instance.UnequipPrimary(true);   
    }
}