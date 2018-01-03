using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : Equipment {

    public GameObject modelPrefab;
    public float strength;
    public float knockStrength;

    private GameObject currentModel;

    void InitModel()
    {
        Transform primaryHolder = FindObjectOfType<PlayerEquipment>().primaryHolder.transform;
        Transform primaryPosition = FindObjectOfType<PlayerEquipment>().primaryPosition.transform;
        currentModel = Instantiate(modelPrefab, primaryPosition.position, primaryPosition.rotation, primaryHolder) as GameObject;
        currentModel.transform.localScale = primaryPosition.localScale;
        PlayerManager.instance.GetPlayer().GetComponent<PlayerAnimator>().hasWeapon = true;
    }

    void UnequipModel()
    {
        if (currentModel != null)
        {
            Destroy(currentModel);
        }
    }

    public override void Equip()
    {
        FindObjectOfType<PlayerStats>().SetAttackStrength(strength);
        InitModel();
    }

    public override void Unequip()
    {
        UnequipModel();
        FindObjectOfType<PlayerStats>().SetAttackStrengthToFist();
        base.Unequip();
    }
}