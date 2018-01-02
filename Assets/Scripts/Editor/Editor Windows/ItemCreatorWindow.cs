using UnityEngine;
using UnityEditor;

public class ItemCreatorWindow : EditorWindow {

    /**

    #region Fields
    #region Gloabl
    string itemName;
    int itemID;
    GameObject holder;
    #endregion

    #region Item
    GameObject createdItem;
    Object itemObj;
    ItemType itemType;
    Sprite icon;
    #endregion

    #region Interactable
    GameObject createdInteractable;
    InteractableType interactableType;
    GameObject interactableObj;
    #endregion
    #endregion

    #region Types
    public enum ItemType { BASIC, EQUIPMENT, INVENTORY, WEAPON, PRIMARY, TOOL, STACKABLE, FOOD_ITEM}
    public enum InteractableType { BASIC, EQUIPPABLE, INVENTORY_ITEM, PICKUPABLE}
    #endregion

    [MenuItem("Window/Item Creator")]
    public static void ShowWindow() {
        GetWindow<ItemCreatorWindow>("Item Creator");
    }

    private void OnGUI()
    {

        GUILayout.Label("Item Creation");

        GUILayout.BeginHorizontal();
        itemType = (ItemType)EditorGUILayout.EnumPopup("Item Type", itemType);
        GUILayout.EndHorizontal();

        itemID = EditorGUILayout.IntSlider(itemID, 0, 100);
        icon = (Sprite)EditorGUILayout.ObjectField(icon, typeof(Sprite), true);
        itemName = EditorGUILayout.TextField(itemName);

        interactableObj = (GameObject)EditorGUILayout.ObjectField(interactableObj, typeof(GameObject), true);
        interactableType = (InteractableType)EditorGUILayout.EnumPopup("Interactable Type", interactableType);

        if (GUILayout.Button("Create Item"))
        {
            CreateItem();
        }
    }

    public void CreateItem()
    {
        holder = new GameObject(itemName);
        createdItem = new GameObject();
        createdItem.name = itemName + " Item";
        switch (itemType)
        {
            case ItemType.BASIC:
                createdItem.AddComponent<Item>();
                break;
            case ItemType.EQUIPMENT:
                createdItem.AddComponent<Equipment>();
                break;
            case ItemType.FOOD_ITEM:
                createdItem.AddComponent<FoodItem>();
                break;
            case ItemType.INVENTORY:
                createdItem.AddComponent<InventoryItem>();
                break;
            case ItemType.PRIMARY:
                createdItem.AddComponent<Primary>();
                break;
            case ItemType.STACKABLE:
                createdItem.AddComponent<GenericStackableItem>();
                break;
            case ItemType.TOOL:
                createdItem.AddComponent<Tool>();
                break;
            case ItemType.WEAPON:
                createdItem.AddComponent<Weapon>();
                break;
        }
        Item item = createdItem.GetComponent<Item>();
        item.id = itemID;
        item.icon = icon;
        item.itemName = itemName;
        item.transform.parent = holder.transform;
        CreateInteractable();
        item.interactable = createdInteractable;
        createdInteractable.transform.parent = holder.transform;
    }

    public void CreateInteractable() {
        createdInteractable = Instantiate(interactableObj) as GameObject;
        createdInteractable.name = itemName + " Interactable";
        switch (interactableType)
        {
            case InteractableType.BASIC:
                createdInteractable.AddComponent(typeof(Interactable));
                break;
            case InteractableType.EQUIPPABLE:
                createdInteractable.AddComponent(typeof(EquippableInteractable));
                break;
            case InteractableType.INVENTORY_ITEM:
                createdInteractable.AddComponent(typeof(InventoryItem));
                break;
            case InteractableType.PICKUPABLE:
                createdInteractable.AddComponent(typeof(Pickupable));
                break;
        }
        Interactable interactable = createdInteractable.GetComponent<Interactable>();
        interactable.interactableName = itemName;
    }
    */
}