using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EquipmentUI : MonoBehaviour {

#region Primary
    public Image primarySlot;
    public Text primaryTitle;

    void UpdatePrimary()
    {
        Primary primary = PlayerEquipment.instance.primary;
        if (primary != null)
        {
            primarySlot.sprite = primary.icon;
            primaryTitle.text = primary.itemName;
        }
        else
        {
            primarySlot.sprite = null;
            primaryTitle.text = "";
        }
    }

    #endregion

    void Update()
    {
        UpdatePrimary();
    }
}