using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RecipeSlot : MonoBehaviour {

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
}