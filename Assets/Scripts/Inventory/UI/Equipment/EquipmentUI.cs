using UnityEngine;
using UnityEngine.UI;

public class EquipmentUI : MonoBehaviour {

    #region Primary
    public Image primarySlot;
    public Text primaryTitle;

    void UpdatePrimary()
    {
        EquipmentSlot slot = primarySlot.GetComponent<EquipmentSlot>();
        Primary primary = PlayerEquipment.instance.primary;
        if (primary != null)
        {
            primarySlot.sprite = primary.icon;
            primaryTitle.text = primary.itemName;
            slot.item = primary;
        }
        else
        {
            primarySlot.sprite = null;
            primaryTitle.text = "";
            slot.item = null;
        }
    }

    #endregion

    #region Tool

    public Image toolSlot;
    public Text toolTitle;

    void UpdateTool() {
        Equipment tool = PlayerEquipment.instance.tool;
        if (tool != null)
        {
            toolSlot.sprite = tool.icon;
            toolTitle.text = tool.itemName;
            toolSlot.GetComponent<EquipmentSlot>().item = tool;
        }
        else
        {
            toolSlot.sprite = null;
            toolTitle.text = "";
            toolSlot.GetComponent<EquipmentSlot>().item = null;
        }
    }

    #endregion

    void Update()
    {
        UpdatePrimary();
        UpdateTool();
    }
}