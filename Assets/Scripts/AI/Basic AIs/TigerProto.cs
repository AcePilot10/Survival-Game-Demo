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
                if (!FindObjectOfType<PlayerHealth>().isDead)
                {
                    anim.SetTrigger("Attack");
                    canAttack = false;
                }
                else
                {
                    state = BasicAIState.PATROL;
                }
            }
            else
            {
                Chase();
            }
        }
    }

    public override void Look()
    {
        if (state != BasicAIState.ATTACK)
        {
            if (CanSeeTarget())
            {
                state = BasicAIState.ATTACK;
            }
        }
    }

    public bool CanSeeTarget()
    {
        RaycastHit hit;
        Vector3 rayDirection = target.position - eyePos.position;
        Ray ray = new Ray(eyePos.position, rayDirection);
        if ((Vector3.Angle(rayDirection, eyePos.forward)) <= fov)
        {
            Debug.DrawRay(eyePos.position, rayDirection * eyesightRange);
            if (Physics.Raycast(ray, out hit, eyesightRange))
            {
                if (hit.collider.gameObject.tag == "Player")
                {
                    return true;
                }
            }
        }
        return false;
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

    public void AnimatorFinishAttack()
    {
        canAttack = true;
    }
}