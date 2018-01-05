using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Item/Tool/Flashlight", fileName = "Flashlight")]
public class Flashlight : Equipment {

    public GameObject model;
    public Vector3 spawnPosition;
    public Vector3 spawnRotation;
    public Vector3 spawnScale;

    private GameObject currentModel;

    public override void InitModel() {
        if (currentModel != null) Destroy(currentModel);
        Transform leftHand = PlayerEquipment.instance.leftHand.transform;
        Vector3 spawnPos = leftHand.TransformPoint(spawnPosition);
        currentModel = Instantiate(model, spawnPos, Quaternion.Euler(spawnRotation), leftHand) as GameObject;
        currentModel.transform.localScale = spawnScale;
    }

    public override void Use()
    {
        PlayerEquipment.instance.EquipTool(this);
        base.Use();
    }

    public override void UnequipModel()
    {
        Destroy(currentModel);
        base.UnequipModel();
    }
}