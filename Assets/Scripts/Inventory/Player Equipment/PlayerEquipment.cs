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
   
    public bool HasPrimary() {
        return primary != null;
    }

    void EquipPrimary(Primary primary) {
        this.primary = primary;
    }

    void UnequipPrimary(bool addToInventory) {
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
    }

    public void Unequip(Equipment item, bool addToInventory) {
        if (item is Primary)
        {
            UnequipPrimary(addToInventory);
        }
        else if (item is Tool) {
            UnequipTool(addToInventory);
        }
    }
}