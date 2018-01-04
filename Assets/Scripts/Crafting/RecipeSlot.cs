using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class RecipeSlot : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler {

    public Recipe recipe;

    public Text title;
    public Image icon;

    private void Update()
    {
        if (recipe != null)
        {
            title.text = recipe.outcome.name;
            icon.sprite = recipe.outcome.icon;
        } 
    }

    public void CraftRecipe()
    {
        if (recipe != null)
        {
            Debug.Log("Attempting to craft recipe: " + recipe.outcome.itemName);
            recipe.Craft();
        }
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        if (recipe != null)
        {
            string items = "Ingredients Needed: ";
            foreach (Item item in recipe.ingrediants)
            {
                items += "," + item.itemName;
            }
            items += ",Result: " + recipe.outcome.itemName;
            items.Replace(",", "\n");
            FindObjectOfType<CraftingMenu>().ingredientDisplay.text = items;
        }
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        FindObjectOfType<CraftingMenu>().ingredientDisplay.text = "";
    }
}