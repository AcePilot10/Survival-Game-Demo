using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryUI : MonoBehaviour {

    #region singleton
    public static InventoryUI instance;

    private void Awake()
    {
        instance = this;
    }
    #endregion

    private void Start()
    {
        UpdateSlots();
    }

    public GameObject slotHolder;

    private void ClearSlots() {
        foreach (Transform child in slotHolder.transform)
        {
            InventorySlot slot = child.GetComponent<InventorySlot>();
            slot.SetItem(null);
        }
    }

    public void UpdateSlots() {
        ClearSlots();
        int stacks = 0;
        //Inventory.instance.items.TrimExcess();
        for (int index = 0; index < slotHolder.transform.childCount; index++)
        {
            Item item = Inventory.instance.items[index];
            InventorySlot slot = slotHolder.transform.GetChild(index - stacks).GetComponent<InventorySlot>();
            //If item exists
            if (item != null)
            {
                //if item is stackable
                if (item.GetType().IsSubclassOf(typeof(IStackable)))
                {
                    //Loop through all slots
                    bool hasItem = false;
                    foreach (Transform child in slotHolder.transform)
                    {
                        InventorySlot childSlot = child.GetComponent<InventorySlot>();
                        //Check if slot has item
                        if (childSlot.HasItem())
                        {
                            Item childSlotItem = childSlot.GetItem();
                            //Check if child slot item is the same as the current item
                            if (childSlotItem.GetInstanceID() == item.GetInstanceID())
                            {
                                hasItem = true;
                                childSlot.AddStack();
                                stacks++;
                            }
                        }
                    }
                    if (!hasItem)
                    {
                        slot.SetItem(item);
                    }
                }
                else {
                    slot.SetItem(item);
                }
            }
        }
    }
}