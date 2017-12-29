using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Creature : Entity {

    public float health = 100f;
    public bool isAlive = true;

    private void Update()
    {
        CheckHealth();
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
}