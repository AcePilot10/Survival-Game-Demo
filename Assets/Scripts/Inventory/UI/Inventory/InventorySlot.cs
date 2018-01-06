using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
public class InventorySlot : MonoBehaviour
{

    #region variables
    private Item item;
    public int amount = 0;

    public Image iconHolder;
    public Text title;
    public Text stackAmount;
    #endregion

    private void Update()
    {
        if (item != null)
        {
            iconHolder.sprite = item.icon;
            title.text = item.itemName;
            stackAmount.text = amount.ToString();
        }
        else
        {
            iconHolder.sprite = null;
            title.text = "";
            stackAmount.text = "";
        }
    }

    public virtual void Click() {
        if (item != null)
        {
            if (Input.GetMouseButtonDown(0))
            {
                item.Use();
            }
        }
    }

    public Item GetItem() {
        return item;
    }

    public void SetItem(Item item) {
        this.item = item;
        if(item != null) {
            amount = 1;
        }
    }

    public void AddStack() {
        amount++;
    }

    public bool HasItem() {
        return item != null;
    }

    public void DropItem() {
        if (amount > 1)
        {
            item.InstantiateDrop();
            Inventory.instance.RemoveItem(item);
            amount--;
        }
        else
        {
            item.Drop();
            SetItem(null);
        }
        InventoryUI.instance.UpdateSlots();
    }
}