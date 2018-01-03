using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flashlight : Tool {

    public GameObject model;

    private Transform holder;
    private Transform position;
    private GameObject currentModel;

    private void Start()
    {
        holder = PlayerEquipment.instance.flashlightHolder.transform;
        position = PlayerEquipment.instance.flashlightPosition.transform;
    }

    public void InitModel() {
        if (currentModel != null) Destroy(currentModel);
        /**
        currentModel = Instantiate(model,
           PlayerEquipment.instance.flashlightPosition.transform.position, PlayerEquipment.instance.flashlightPosition.transform.rotation
         , PlayerEquipment.instance.flashlightHolder.transform) as GameObject;
    */
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
        InitModel();
        base.Use();
    }
}