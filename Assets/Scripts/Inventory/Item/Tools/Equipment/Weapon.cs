using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : Equipment {

    public GameObject modelPrefab;
    public float strength;

    private GameObject currentModel;

    void InitModel()
    {
        Transform primaryHolder = GameObject.FindGameObjectWithTag("Primary Holder").transform;
        Transform primaryPosition = GameObject.FindGameObjectWithTag("Primary Position").transform;
        currentModel = Instantiate(modelPrefab) as GameObject;
        currentModel.transform.position = primaryPosition.position;
        currentModel.transform.parent = primaryHolder;
        currentModel.transform.rotation = primaryPosition.rotation;
        currentModel.transform.localScale = primaryPosition.localScale;
        currentModel.transform.parent = primaryHolder;
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