using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Equipment : Tool {

    public virtual void Equip(){}

    public virtual void Unequip()
    {
        PlayerEquipment.instance.Unequip(this, true);
    }

    public override void Pickup()
    {
        Equip();
    }
}
