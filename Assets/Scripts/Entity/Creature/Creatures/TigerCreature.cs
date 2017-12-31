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

    public override void Die()
    {
        anim.SetTrigger("Die");
    }

    public void AnimatorDie() {
        base.Die();
    }
}