using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class InventoryItemOptions : MonoBehaviour, IPointerClickHandler {

    public InventorySlot slot;
    public bool displayOptions = false;
    public GameObject optionsPanel;

    public void OnPointerClick(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Right)
        {
            ToggleOptions();
        }
    }

    void ToggleOptions()
    {
        if (slot.HasItem())
        {
            optionsPanel.SetActive(!optionsPanel.activeSelf);
        }
    }

    public void DropItem() {
        optionsPanel.SetActive(false);
        slot.DropItem();
    }
}