using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class EquipmentSlot : MonoBehaviour, IPointerClickHandler
{

    public EquipmentType type;

    private bool showingUI = false;

    void IPointerClickHandler.OnPointerClick(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Right) {
            ToggleUI();
        }
    }

    public void ToggleUI() {
        showingUI = !showingUI;
    }

    void OnGUI() {
        if (showingUI) {
            Rect pos = new Rect(Screen.width / 2, Screen.height / 2, Screen.width / 2, Screen.height / 2);
            GUIContent content = new GUIContent();
            content.image = null;
            content.text = "Test Frame";
            GUI.BeginGroup(pos, "Options");
            GUI.Label(new Rect(0, 15, 100, 100), "Test Label");
            if (GUI.Button(new Rect(0, 25, 100, 100), "Drop"))
            {
                if (PlayerEquipment.instance.HasPrimary())
                {
                    ToggleUI();
                    PlayerEquipment.instance.primary.Unequip();
                }
            }
            GUI.EndGroup();
        }
    }
}