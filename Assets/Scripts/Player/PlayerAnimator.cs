﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimator : MonoBehaviour {

    public Animator anim;
    public float walkThreshold;
    public bool hasWeapon = false;

    private CharacterController controller;

    private void Awake()
    {
        controller = GetComponent<CharacterController>();
    }

    private void Update()
    {
        UpdateAttacking();   
    }

    #region attacking

    void UpdateAttacking()
    {
        anim.SetBool("HasWeapon", hasWeapon);
        anim.SetBool("Walking", (controller.velocity.magnitude >= walkThreshold));
    }

    public void PunchRandom() {
        int rdm = Random.Range(1, 3);
        switch (rdm)
        {
            case 1:
                PunchLeft();
                break;
            case 2:
                PunchRight();
                break;
        }
    }

    void PunchLeft() {
        anim.SetTrigger("Punch Left");
    }

    void PunchRight() {
        anim.SetTrigger("Punch Right");
    }

    public void Swing()
    {
        anim.SetTrigger("Swing");
    }
    #endregion

}