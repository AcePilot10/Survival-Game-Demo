using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour {

    public int id;
    public Sprite icon;
    public string itemName;
    public GameObject interactable;

    private void Awake()
    {
        Init();
    }

    public virtual void Init(){}

    public virtual void Pickup() {
        Inventory.instance.AddItem(this);
    }

    public virtual void Drop()
    {
        GameObject obj = Instantiate(interactable) as GameObject;
        Vector3 pos = transform.position + (transform.forward * 3);
        pos.y = transform.position.y - 3;
        obj.transform.position = pos;
        Inventory.instance.RemoveItem(this);
    }

    public virtual void Use()
    {
        Debug.Log("Used: " + itemName);
    }
}