using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class TigerProto : BasicAI
{
    #region Animation Control
    public Animator anim;
    private float velMag;
    #endregion

    public float damage;

    private void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;
    }

    public override void Attack()
    {
        if (canAttack)
        {
            if (Vector3.Distance(transform.position, target.position) <= attackRange)
            {
                anim.SetTrigger("Attack");
            }
            else
            {
                Chase();
            }
        }
    }

    public override void Look()
    {
        //For now we will do a raycast for just forward
        RaycastHit hit;
        Ray ray = new Ray(eyePos.position, eyePos.forward);
        Physics.Raycast(ray, out hit, eyesightRange);
        if (hit.collider != null)
        {
            GameObject obj = hit.collider.gameObject;
            if (obj.tag == "Player")
            {
                state = BasicAIState.ATTACK;
            }
        }
    }

    public override void UpdateState()
    {
        anim.SetFloat("VelMag", agent.speed);
        base.UpdateState();
    }

    public void AnimatorDoDamage()
    {
        RaycastHit hit;
        Ray ray = new Ray(eyePos.position, eyePos.forward);
        Physics.Raycast(ray, out hit, eyesightRange);
        if (hit.collider != null)
        {
            GameObject obj = hit.collider.gameObject;
            if (obj.tag == "Player")
            {
                obj.GetComponent<PlayerHealth>().TakeDamage(damage);
                Debug.Log("AI DID DAMAGE!");
            }
        }
    }
}