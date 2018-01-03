using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Recipes/Create Recipe", fileName = "Recipe")]
public class Recipe : ScriptableObject {

    #region Main

    public Item[] ingrediants;
    public Item outcome;

    public virtual void Craft() {
        if (HasItems())
        {
            RemoveItems();
            AddOutcome();
        }
        else
        {
            Debug.Log("You don't have the required ingredients!");
        }
    }
    
    #endregion

    #region Helpers

    private bool HasItems() {
        if (Inventory.instance.items.Count > 0)
        {
            List<Item> inventory = new List<Item>();
            foreach (Item item in Inventory.instance.items) { inventory.Add(item); }

            foreach (Item item in ingrediants)
            {
                if (inventory.Contains(item))
                {
                    inventory.Remove(item);
                }
                else
                {
                    return false;
                }
            }
        }
        else
        {
            return false;
        }
        return true;
    }

    public virtual void RemoveItems() {
        foreach (Item item in ingrediants)
        {
            Inventory.instance.RemoveItem(item);
        }
    }

    public virtual void AddOutcome()
    {
        Inventory.instance.AddItem(outcome);
        Debug.Log("Crafted: " + outcome.itemName);
    }

    #endregion
}