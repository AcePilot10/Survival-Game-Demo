using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class DoorInteractable : Interactable {

    private bool open = false;
    private Animator anim;

    private void Awake()
    {
        anim = GetComponent<Animator>();
    }

    public override void Interact()
    {
        ToggleDoor();
        base.Interact();
    }

    void ToggleDoor() {
        if (open)
        {
            open = false;
            anim.SetTrigger("Close");
        }
        else {
            open = true;
            anim.SetTrigger("Open");
        }
    }
}