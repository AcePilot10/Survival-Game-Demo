using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BasicAI : MonoBehaviour {

    #region States

    public enum BasicAIState {
        IDLE, PATROL, ATTACK
    }
    #endregion

    #region variables
    #region settings
    //settings
    public BasicAIState state;
    public float fov;
    public float attackRange;
    public float eyesightRange;
    public float attackStoppingDistance = 3f;
    public NavMeshAgent agent;
    public Entity entity;
    public Transform eyePos;
    public float chaseMaximumRange;
    #endregion
    
    //speeds
    public float walkSpeed;
    public float runSpeed;

    //patrol points
    public Transform[] patrolPoints;
    public float patrolPointStoppingRange;
    public int patrolIndex = 0;

    //targeting
    protected Transform target;
    protected bool canAttack = true;
    #endregion

    #region helpers
    void NextPatrolPoint()
    {
        if (patrolIndex < patrolPoints.Length)
        {
            patrolIndex++;
        }
        else
        {
            patrolIndex = 0;
        }
    }

    private void Update()
    {
        UpdateState();
    }
    #endregion

    #region AI
    public virtual void Patrol() {
        if (patrolPoints.Length > 0)
        {
            agent.speed = walkSpeed;
            Vector3 target = patrolPoints[patrolIndex].position;
            agent.destination = target;
            if (Vector3.Distance(transform.position, target) <= patrolPointStoppingRange)
            {
                NextPatrolPoint();
            }
        }
        else
        {
            Idle();
        }
    }

    public virtual void Chase() {
        agent.speed = runSpeed;
        agent.stoppingDistance = attackStoppingDistance;
        agent.destination = target.position;
        if (Vector3.Distance(transform.position, target.transform.position) >= chaseMaximumRange) {
            state = BasicAIState.PATROL;
        }
    }

    public virtual void Attack() {
        if (canAttack)
        {
            if (Vector3.Distance(transform.position, target.position) <= attackRange)
            {
                if (target.GetComponent<PlayerHealth>().health > 0)
                {
                    //Attack
                }
            }
            else
            {
                Chase();
            }
        }
    }

    public virtual void Idle() {
        agent.speed = 0;
    }

    public virtual void Look() {
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

    public virtual void UpdateState() {
        Look();
        switch (state)
        {
            case BasicAIState.PATROL:
                Patrol();
                break;
            case BasicAIState.ATTACK:
                Attack();
                break;
            case BasicAIState.IDLE:
                Idle();
                break;
        }
    }
    #endregion
}