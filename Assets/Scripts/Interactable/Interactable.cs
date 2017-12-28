﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour {

    public string interactableName;

    public virtual void Interact() {
        Debug.Log("Interacted with: " + interactableName);
    }
}