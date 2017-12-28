using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Entity : MonoBehaviour {

    public int id;
    public string entityName;

    private void Awake()
    {
        Initiate();
    }

    public virtual void Attack(float amount) { 
        Debug.Log("Attacked: " + entityName);
    }

    public virtual void Initiate() {

    }

    private void Start()
    {
        Initiate();
    }
}