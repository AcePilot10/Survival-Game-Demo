using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class ModelAnimator : MonoBehaviour {

    public Animator anim;
    public CharacterController controller;
    public FirstPersonController fps;

    private float speed;
    private float direction;

    private void FixedUpdate()
    {
        speed = controller.velocity.y;
        direction = controller.velocity.x;
    }

    private void Update()
    {
        anim.SetFloat("Speed", speed);
        anim.SetFloat("Direction", direction);
    }
}
