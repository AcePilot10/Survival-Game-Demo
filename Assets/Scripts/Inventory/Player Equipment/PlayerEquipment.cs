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
<<<<<<< HEAD
        primary.Equip();
    }

    void UnequipPrimary(bool addToInventory) {
        FindObjectOfType<PlayerAnimator>().hasWeapon = false;
    }

    void UnequipPrimary(bool addToInventory) {
=======
    }

    void UnequipPrimary(bool addToInventory) {
>>>>>>> parent of 1633f48... V1.1.0
        if(addToInventory)
        {
            Inventory.instance.AddItem(primary);
        }
        primary.Unequip();
        primary = null;
    }
    #endregion


    #region Tool
    public Equipment tool;
    public GameObject flashlightHolder;
    public GameObject flashlightPosition;

    public bool HasTool() {
        return tool != null;
    }

    void EquipTool(Equipment tool) {
        this.tool = tool;
    }
    
    void UnequipTool(bool addToInventory) {
        if (addToInventory) {
            Inventory.instance.AddItem(tool);
        }
        tool.Unequip();
        tool = null;
    }
    #endregion


    public void Equip(Equipment item) {
        if (item is Primary)
        {
            EquipPrimary(item as Primary);
        }

        else if (item is Tool)
        {
            EquipTool(item as Equipment);
        }
        Inventory.instance.RemoveItem(item);
<<<<<<< HEAD

=======
>>>>>>> parent of 1633f48... V1.1.0
    }

    public void Unequip(Equipment item, bool addToInventory) {
        if (item is Primary)
        {
            UnequipPrimary(addToInventory);
        }
    }
}