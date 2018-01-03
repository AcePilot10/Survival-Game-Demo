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

    #region Variables
    public List<Item> items;
    public GameObject uiObject;

    private FirstPersonController controller;
    private bool opened = false;
    private MouseLook mouseLook;

    #endregion

    private void Start()
    {
        controller = GetComponent<FirstPersonController>();
        Cursor.visible = false;
        mouseLook = GameObject.FindObjectOfType<FirstPersonController>().m_MouseLook;
    }

    #region functionality
    public bool IsFull()
    {
        return !items.Contains(null);
    }

    public bool ContainsItem(Item item)
    {
        foreach (Item current in items)
        {
            if (current.id == item.id)
            {
                return true;
            }
        }
        return false;
    }

    private void AddItemToInventory(Item item)
    {
        for (int index = 0; index < items.Count; index++)
        {
            Item currentItem = items[index];
            if (currentItem == null)
            {
                items[index] = item;
                break;
            }
        }
    }

    private void RemoveItemFromItems(Item item)
    {
        for (int index = 0; index < items.Count; index++)
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

    /**
    public void OrganizeInventory()
    {
        foreach(Item item in items)
        {
            if (item == null)
            {
                //items.Remove(item);
                items.TrimExcess();
            }
        }
    }*/
    #endregion

    #region Main Functions
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
        uiObject.gameObject.SetActive(true);
        mouseLook.m_cursorIsLocked = false;
        controller.canMove = false;
    }

    void CloseInventory() {
        uiObject.gameObject.SetActive(false);
        mouseLook.m_cursorIsLocked = true;
        controller.canMove = true;
    }

    public void AddItem(Item item) {
        Debug.Log("Succesfully added: " + item.itemName + " to inventory!");
        AddItemToInventory(item);
        FindObjectOfType<InventoryUI>().UpdateSlots();
    }

    public void RemoveItem(Item item) {
        Debug.Log("Attempting to remove: " + item.itemName);
        RemoveItemFromItems(item);
        InventoryUI.instance.UpdateSlots();
    }
    #endregion
}