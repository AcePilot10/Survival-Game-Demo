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

   void ToggleOptions() {
        displayOptions = !displayOptions;
    }

    void Update()
    {
        if (slot.HasItem())
        {
            optionsPanel.SetActive(displayOptions);
        }
    }

    public void DropItem() {
        slot.DropItem();
    }
}