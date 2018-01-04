using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Creature : Entity {

    public float health = 100f;
    public bool isAlive = true;
    public Item[] drops;

    private void Update()
    {
        CheckHealth();
    }

    public override void Attack(float amount)
    {
        ReduceHealth(amount);
        base.Attack(amount);
    }

    public virtual void ReduceHealth(float amount)
    {
        health -= amount;
    }

    void CheckHealth()
    {
        if (health <= 0)
        {
            if (isAlive)
            {
                Die();
            }
        }
    }

    public virtual void Die()
    {
        isAlive = false;
    }

    public virtual void DropItems()
    {
        foreach(Item item in drops)
        {
            item.InstantiateDrop();
        }
    }
}