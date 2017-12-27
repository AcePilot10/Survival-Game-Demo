using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Pickupable : Interactable {

#region Variables
    public bool isHeld = false;
    public float holdDistance;
    public float smoothing;

    private Quaternion originalRotation;
    private Rigidbody rb;
#endregion

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    public override void Interact()
    {
        HandlePickup();
        base.Interact();
    }

    void HandlePickup() {
        if (!isHeld)
        {
            Pickup();
        }
        else {
            Drop();
        }
    }

    void Pickup() {
        rb.isKinematic = true;
        isHeld = true;
        originalRotation = transform.rotation;
        transform.parent = Camera.main.transform;
    }

    void Drop() {
        rb.isKinematic = false;
        isHeld = false;
        transform.parent = null;
    }

    private void Update()
    {
        if (isHeld) {
            UpdatePosition();
        }
    }

    private void UpdatePosition() {
        transform.rotation = originalRotation;
    }
}