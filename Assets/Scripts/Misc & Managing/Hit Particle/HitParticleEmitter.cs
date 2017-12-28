using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitParticleEmitter : MonoBehaviour {

    public GameObject particleObject;

    public void Play(Vector3 position)
    {
        GameObject obj = Instantiate(particleObject) as GameObject;
        obj.transform.position = position;
        obj.GetComponent<ParticleSystem>().Play();
        StartCoroutine(DestroyDelay(obj.GetComponent<ParticleSystem>().main.duration, obj));
    }

    IEnumerator DestroyDelay(float time, GameObject obj)
    {
        yield return new WaitForSeconds(time);
        Destroy(obj);
    }
}