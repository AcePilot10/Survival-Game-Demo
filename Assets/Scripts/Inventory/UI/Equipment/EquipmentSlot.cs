using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class EquipmentSlot : MonoBehaviour, IPointerClickHandler
{

    public EquipmentType type;
    public Equipment item;
    private bool showingUI = false;
    public GameObject optionsHolder;

    void IPointerClickHandler.OnPointerClick(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Right) {
            ToggleUI();
        }
    }

    public void ToggleUI() {
        showingUI = !showingUI;
    }

    void Update()
    {
        if (showingUI)
        {
            optionsHolder.SetActive(true);
        }
        else {
            optionsHolder.SetActive(false);
        }
    }

    public void Unequip() {
        PlayerEquipment.instance.Unequip(item, true);
    }
}