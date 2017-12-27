using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tree : Resource {

    public float destroyForce;
    public float destroyDelay;

    public GameObject[] droppings;
    public float spreadRadius = 2f;

    public override void Die()
    {
        Rigidbody rb = gameObject.AddComponent<Rigidbody>();
        rb.isKinematic = false;
        Vector3 force = PlayerManager.instance.GetPlayer().transform.TransformDirection(Vector3.forward);
        rb.useGravity = true;
        rb.AddForce(force * destroyForce, ForceMode.Impulse);
        Debug.Log("Tree Died!");
        StartCoroutine(DestroyTree());
        base.Die();
    }

    IEnumerator DestroyTree() {
        yield return new WaitForSeconds(destroyDelay);
        Drop();
        Destroy(gameObject);
    }

    void Drop() {
        foreach (GameObject obj in droppings) {
            GameObject dropped = Instantiate(obj) as GameObject;
            float originalX = transform.position.x;
            float originalZ = transform.position.z;
            float randX = Random.Range(originalX-spreadRadius, originalX+spreadRadius);
            float randZ = Random.Range(originalZ-spreadRadius, originalZ+spreadRadius);
            Vector3 pos = new Vector3(randX, transform.position.y, randZ);
            dropped.transform.position = pos;
        }
    }
}