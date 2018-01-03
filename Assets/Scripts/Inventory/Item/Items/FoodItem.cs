using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Item/Food", fileName = "Food")]
public class FoodItem : IStackable {

    public float foodAmount;

    public override void Use()
    {
        PlayerManager.instance.GetPlayer().GetComponent<PlayerHealth>().AddHunger(foodAmount);
        base.Use();
        Inventory.instance.RemoveItem(this);
    }
}