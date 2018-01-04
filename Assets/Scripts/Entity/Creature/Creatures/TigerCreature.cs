using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TigerCreature : Creature
{

    private Animator anim;

    private void Awake()
    {
        anim = GetComponent<Animator>();
    }

    public override void Attack(float amount)
    {
        anim.SetTrigger("Hit");
        base.Attack(amount);
    }

    public override void Die()
    {
        anim.SetTrigger("Hurt");
        Debug.Log("Tiger Died!");
    }

    public void AnimatorDie() {
        DropItems();
        Destroy(this);
    }
}