using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class PlayerInput : MonoBehaviour {

    private void Update()
    {
        CheckInput();  
    }

    void CheckInput() {
        if (Input.GetMouseButtonDown(0))
        {
           InitAttack();
        }

        if (Input.GetMouseButtonDown(1))
        {
            DoInteract();
        }

        if (Input.GetKeyDown(KeyCode.I)) {
            GetComponent<Inventory>().ToggleInventory();
        }
    }

    void InitAttack() {
        FirstPersonController fps = GameObject.FindObjectOfType<FirstPersonController>();
        if (fps.canMove)
        {
            PlayerAnimator animator = GetComponent<PlayerAnimator>();
            if (animator.hasWeapon)
            {
                animator.Swing();
            }
            else
            {
                animator.PunchRandom();
            }
        }
    }

    void DoAttack() {
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(new Vector2(Screen.width/2, Screen.height/2));
        Physics.Raycast(ray, out hit, PlayerManager.stats.entityReach);
        if (hit.collider != null)
        {
            GameObject obj = hit.collider.gameObject;
            Entity entity = obj.GetComponent<Entity>();
            if (entity != null)
            {
                entity.Attack(PlayerManager.stats.entityAttackStrength);
            }
            HitEffect(obj, hit);
        }
    }


    void HitEffect(GameObject obj, RaycastHit hit)
    {
        //Hit particles
        if (obj.GetComponent<HitParticleEmitter>() != null)
        {
            if (obj.GetComponent<HitParticleEmitter>().particleObject != null)
            {
                obj.GetComponent<HitParticleEmitter>().Play(hit.point);
            }
        }
        //Add Force
        if (obj.GetComponent<Rigidbody>() != null) {
            Rigidbody rb = obj.GetComponent<Rigidbody>();
            if (PlayerEquipment.instance.HasPrimary()) {
                Primary primary = PlayerEquipment.instance.primary;
                rb.AddForce(transform.forward * primary.knockStrength, ForceMode.Impulse);
            }
        }
    }

    void DoInteract() {
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(new Vector2(Screen.width / 2, Screen.height / 2));
        Physics.Raycast(ray, out hit, PlayerManager.stats.interactableReach);
        if (hit.collider != null)
        {
            GameObject obj = hit.collider.gameObject;
            Interactable interactable = obj.GetComponent<Interactable>();
            if (interactable != null)
            {
                interactable.Interact();
            }
        }
    }
}