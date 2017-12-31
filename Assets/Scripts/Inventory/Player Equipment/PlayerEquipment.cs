using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerEquipment : MonoBehaviour {

    #region singleton
    public static PlayerEquipment instance;

    private void Awake()
    {
        instance = this;
    }
    #endregion

    public EquipmentUI ui;

    #region Primary
    public Primary primary;
    public GameObject primaryHolder;
    public GameObject primaryPosition;
    public GameObject flashlightHolder;
    public GameObject flashlightPosition;
   
    public bool HasPrimary() {
        return primary != null;
    }

    void EquipPrimary(Primary primary) {
        this.primary = primary;
        primary.Equip();
    }

    void UnequipPrimary(bool addToInventory) {
        FindObjectOfType<PlayerAnimator>().hasWeapon = false;
        if(addToInventory)
        {
            Inventory.instance.AddItem(primary);
        }
        primary = null;
    }
    #endregion

    public void Equip(Equipment item) {
        if (item is Primary)
        {
            EquipPrimary(item as Primary);
        }
    }

    public void Unequip(Equipment item, bool addToInventory) {
        if (item is Primary)
        {
            UnequipPrimary(addToInventory);
        }
    }
}