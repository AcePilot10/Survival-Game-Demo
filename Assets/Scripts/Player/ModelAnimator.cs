using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class ModelAnimator : MonoBehaviour {

    #region Variables
    public Animator anim;
    public CharacterController controller;
    public FirstPersonController fps;

    private float speed;
    private float direction;
    private bool sprinting;
    #endregion

    #region event registration
    private void OnEnable()
    {
        FirstPersonController.OnJump += OnPlayerJump;
    }

    private void OnDisable()
    {
        FirstPersonController.OnJump -= OnPlayerJump;
    }

    void OnPlayerJump()
    {
        anim.SetTrigger("Jump");
    }
    #endregion

    private void FixedUpdate()
    {
        speed = fps.speed;
        direction = fps.direction;
        sprinting = !fps.m_IsWalking;
    }

    private void Update()
    {
        anim.SetFloat("Speed", speed);
        anim.SetFloat("Direction", direction);
        anim.SetBool("Sprinting", sprinting);
    }
}
