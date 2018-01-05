using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Item/Placeable", fileName = "Placeable")]
public class Placeable : Item {

    #region variables

    public GameObject placeableObject;
    public Vector3 spawnPos;

    private bool isPlacing = false;

    private GameObject currentObject;

    #endregion

    private void OnEnable()
    {
        PlayerInput.OnPlaceAttempt += Place;
    }

    private void OnDisable()
    {
        PlayerInput.OnPlaceAttempt -= Place;
    }

    public override void Drop()
    {
        //Do nothing
    }

    public override void Use()
    {
        InitPlace();
    }

    public virtual void InitPlace()
    {
        if (currentObject != null) Destroy(currentObject);
        currentObject = Instantiate(placeableObject) as GameObject;
        currentObject.transform.parent = Camera.main.transform;
        currentObject.transform.position = Camera.main.transform.TransformPoint(spawnPos);
        Inventory.instance.ToggleInventory();
        Debug.Log("Instantiated: " + currentObject.name);
        isPlacing = true;
    }

    public virtual void Place()
    {
        if (isPlacing)
        {
            currentObject.transform.parent = null;
            currentObject = null;
            isPlacing = false;
            Inventory.instance.RemoveItem(this);
            Debug.Log("Placed item!");
        }
    }
}