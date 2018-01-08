using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : Equipment {

    public GameObject modelPrefab;
    public float strength;
    public float knockStrength;
    public Vector3 spawnPosition;
    public Vector3 spawnRotation;
    public Vector3 spawnScale;

    private GameObject currentModel;

    public override void InitModel()
    {
        Transform rightHand = PlayerEquipment.instance.rightHand.transform;
        currentModel = Instantiate(modelPrefab) as GameObject;

        Vector3 localSpawnPos = rightHand.TransformPoint(spawnPosition);
        Vector3 localRotation = rightHand.TransformPoint(spawnRotation);

        currentModel.transform.parent = rightHand;

        currentModel.transform.position = localSpawnPos;

        //currentModel.transform.rotation = Quaternion.Euler(spawnRotation);
        currentModel.transform.localRotation = Quaternion.Euler(spawnRotation);

        PlayerManager.instance.GetPlayer().GetComponent<PlayerAnimator>().hasWeapon = true;
    }

    public override void UnequipModel()
    {
        if (currentModel != null)
        {
            Destroy(currentModel);
        }
    }

    public override void Equip()
    {
        FindObjectOfType<PlayerStats>().SetAttackStrength(strength);
        FindObjectOfType<PlayerAnimator>().hasWeapon = false;
        InitModel();
    }

    public override void Unequip()
    {
        UnequipModel();
        base.Unequip();
    }
}