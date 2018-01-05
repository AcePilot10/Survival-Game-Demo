using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Item/Basic Item", fileName = "Item")]
[System.Serializable]
public class Item : ScriptableObject {

    public int id;
    public Sprite icon;
    public string itemName;
    public GameObject interactable;

    private void Awake()
    {
        Init();
    }

    public virtual void Init() { }

    public virtual void Pickup() {
        Inventory.instance.AddItem(this);
    }

    public virtual void Drop()
    {
        GameObject obj = Instantiate(interactable) as GameObject;
        Vector3 pos = PlayerManager.instance.GetPlayer().transform.position + (PlayerManager.instance.GetPlayer().transform.forward * 3);
        pos.y = PlayerManager.instance.GetPlayer().transform.position.y;
        pos.z += 0.2f;
        obj.transform.position = pos;
        Inventory.instance.RemoveItem(this);
    }

    public virtual void Use()
    {
        Debug.Log("Used: " + itemName);
    }

    public virtual void InstantiateDrop() {
        GameObject obj = Instantiate(interactable) as GameObject;
        Vector3 pos = PlayerManager.instance.GetPlayer().transform.position + (PlayerManager.instance.GetPlayer().transform.forward * 3);
        pos.y = PlayerManager.instance.GetPlayer().transform.position.y - 3;
        obj.transform.position = pos;
    }
}