using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Equipment : Tool {


    public override void Unequip()
    {
        UnequipModel();
    }

    public override void Equip()
    {
        PlayerEquipment.instance.Equip(this);
        InitModel();
        base.Equip();
    }
}
