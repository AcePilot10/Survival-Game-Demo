using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToolSlot : EquipmentSlot {

    public override void Unequip()
    {
        PlayerEquipment.instance.UnequipPrimary(true);   
    }
}