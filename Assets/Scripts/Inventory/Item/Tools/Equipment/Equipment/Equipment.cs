using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ToolItem;

public class Equipment : Tool {

    public override void Unequip()
    {
        UnequipModel();
        base.Unequip();
    }

    public override void Equip()
    {
        InitModel();
        base.Equip();
    }
}
