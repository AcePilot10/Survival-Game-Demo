using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Resource : Entity {

    public float hitpoints;

    private bool alive = true;

    public override void Attack(float amount)
    {
        base.Attack(amount);
        hitpoints -= amount;
    }

    private void Update()
    {
        if (alive)
        {
            if (hitpoints <= 0)
            {
                Die();
            }
        }
    }

    public virtual void Die()
    {
        alive = false;
    }
}