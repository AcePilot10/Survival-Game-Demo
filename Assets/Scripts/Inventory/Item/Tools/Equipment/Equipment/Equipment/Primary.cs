using UnityEngine;

[CreateAssetMenu(menuName = "Item/Equipment/Primary", fileName = "Primary")]
public class Primary : Weapon {

    public override void Use()
    {
        PlayerEquipment.instance.EquipPrimary(this);
        base.Use();
    }

    public override void Drop()
    {
        base.Drop();
        base.Unequip();
    }

    public void AddToInventory() {
        Unequip();
        PlayerEquipment.instance.UnequipPrimary(true);
    }
}