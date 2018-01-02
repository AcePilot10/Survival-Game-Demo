using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class EquipmentSlot : MonoBehaviour, IPointerDownHandler
{

    public EquipmentType type;
    public Equipment item;
    private bool showingUI = false;
    public GameObject optionsHolder;

    public void OnPointerDown(PointerEventData eventData)
    {
        if (item != null)
        {
            ToggleUI();
        }
    }

    public void ToggleUI() {
        showingUI = !showingUI;
        optionsHolder.SetActive(showingUI);
    }

    public void Drop() {
        Debug.Log("Drop Clicked");
        item.Drop();
        showingUI = false;
    }
}