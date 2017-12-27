using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Entity : MonoBehaviour {

    public int id;
    public string entityName;

    public virtual void Interact() {

    }

    public virtual void Attack(float amount) {
        //Debug.Log(name + " has been atacked for " + amount + " hit points!");
    }

    public virtual void Initiate() {

    }

    private void Start()
    {
        Initiate();
    }
}