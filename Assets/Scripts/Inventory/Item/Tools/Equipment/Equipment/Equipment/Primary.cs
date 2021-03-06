﻿using UnityEngine;

[CreateAssetMenu(menuName = "Item/Equipment/Primary", fileName = "Primary")]
public class Primary : Weapon {

    public override void Use()
    {
        PlayerEquipment.instance.EquipPrimary(this);
        base.Use();
    }
}