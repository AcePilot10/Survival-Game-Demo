using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Item/Tool/Flashlight", fileName = "Flashlight")]
public class Flashlight : Equipment {

    public GameObject model;

    private Transform holder;
    private Transform position;
    private GameObject currentModel;

    private void Start()
    {
        holder = PlayerEquipment.instance.flashlightHolder.transform;
        position = PlayerEquipment.instance.flashlightPosition.transform;
    }

    public override void InitModel() {
        if (currentModel != null) Destroy(currentModel);
        Transform holder = PlayerEquipment.instance.flashlightHolder.transform;
        Transform position = PlayerEquipment.instance.flashlightPosition.transform;
        currentModel = Instantiate(model) as GameObject;
        currentModel.transform.parent = holder;
        currentModel.transform.position = position.position;
        currentModel.transform.rotation = position.transform.rotation;
        currentModel.transform.localScale = position.transform.localScale;
        currentModel.transform.localScale = position.localScale;
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