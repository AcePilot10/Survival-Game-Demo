using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

[RequireComponent(typeof(Image))]
public class InventorySlot : MonoBehaviour, IPointerClickHandler
{

    private Item item;

    public Image iconHolder;
    public Text title;

    private bool displayOptions = false;

    private void Update()
    {
        if (item != null)
        {
            iconHolder.sprite = item.icon;
            title.text = item.itemName;
        }
        else
        {
            iconHolder.sprite = null;
            title.text = "";
        }
    }

    public virtual void Click() {
        if (item != null)
        {
            item.Use();
        }
    }

    public virtual void ToggleOptions() {
        displayOptions = !displayOptions;
    }

    public Item GetItem() {
        return item;
    }

    public void SetItem(Item item) {
        this.item = item;
    }

    public void OnPointerClick(PointerEventData eventData)
    //Used for detected right clicks
    {
        if (eventData.button == PointerEventData.InputButton.Right) {
            ToggleOptions();
        }
    }

    void OnGUI() {
        if (displayOptions) {
            Rect pos = new Rect(Screen.width/2, Screen.height/2, Screen.width/2, Screen.height/2);
            GUIContent content = new GUIContent();
            content.image = null;
            content.text = "Test Frame";
            GUI.BeginGroup(pos, "Options");
            GUI.Label(new Rect(0, 15, 100, 100), "Test Label");
            if (GUI.Button(new Rect(0, 25, 100, 100), "Drop")) {
                if (item != null) {
                    ToggleOptions();
                    item.Drop();
                }
            }
            GUI.EndGroup();
        }
    }
}