using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryUI : MonoBehaviour {

    public GameObject slotHolder;

    private Inventory inventory;

    private void Awake()
    {
        inventory = Inventory.instance;
    }

    void UpdateSlots()
    {
        try
        {
            for (int index = 0; index < slotHolder.transform.childCount; index++)
            {
                Item item = inventory.items[index];
                InventorySlot slot = slotHolder.transform.GetChild(index).GetComponent<InventorySlot>();
                if (item != null)
                {
                    slot.SetItem(item);
                }
                else
                {
                    slot.SetItem(null);
                }
            }
        }
        catch (System.IndexOutOfRangeException ex) { }
    }

    private void Update()
    {
        UpdateSlots();
    }
}
