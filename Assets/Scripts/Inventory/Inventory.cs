using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class Inventory : MonoBehaviour {

#region singleton
    public static Inventory instance;

    private void Awake()
    {
        instance = this;
    }
    #endregion

    public Item[] items;
    public InventoryUI ui;

    private FirstPersonController controller;
    private bool opened = false;
    private MouseLook mouseLook;

    private void Start()
    {
        controller = GetComponent<FirstPersonController>();
        Cursor.visible = false;
        mouseLook = PlayerManager.instance.GetPlayer().GetComponent<FirstPersonController>().m_MouseLook;
    }

    public void ToggleInventory() {
        opened = !opened;
        switch (opened) 
        {
            case true:
                OpenInventory();
                break;

            case false:
                CloseInventory();
                break;
        }
    }

    void OpenInventory() {
        ui.gameObject.SetActive(true);
        mouseLook.m_cursorIsLocked = false;
        controller.canMove = false;
    }

    void CloseInventory() {
        ui.gameObject.SetActive(false);
        mouseLook.m_cursorIsLocked = true;
        controller.canMove = true;
    }

    public bool IsFull() {
        return items.Length == (ui.slotHolder.transform.childCount);
    }

    private void AddToItems(Item item) {
        for (int index = 0; index < items.Length; index++) {
            Item currentItem = items[index];
            if (currentItem == null) {
                items[index] = item;
                break;
            }
        }
    }

    private void RemoveItemFromItems(Item item) {
        for (int index = 0; index < items.Length; index++)
        {
            Item currentItem = items[index];
            if (currentItem != null)
            {
                if (currentItem.GetInstanceID() == item.GetInstanceID())
                {
                    Debug.Log("Removed Item!");
                    items[index] = null;
                    break;
                }
            }
        }
    }

    public void AddItem(Item item) {
        AddToItems(item);
        Debug.Log("Succesfully added: " + item.itemName + " to inventory!");
    }

    public void RemoveItem(Item item) {
        Debug.Log("Attempting to remove: " + item.itemName);
        RemoveItemFromItems(item);
    }
}