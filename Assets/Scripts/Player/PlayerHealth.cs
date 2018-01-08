using System.Collections;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;
using UnityEngine.SceneManagement;
using System.Collections.Generic;

public class PlayerHealth : MonoBehaviour {

    public float health;
    public float hunger;
    public float stamina;

    public float starveDamageAmount;

    public float respawnDelay;
    public Camera deadCamera;
    public GameObject playerRagdoll;

    private bool isFatigued = false;
    [HideInInspector]public bool isDead = false;



    #region Settings
    public float staminaZeroDelay;
    public float foodDrainSpeed;
    public float fatiguedSpeedMultiplier;
    #endregion

    private void Update()
    {
        CheckStamina();
        ReduceHunger();
        CheckHealth();
    }

    #region Health Management

    #region hunger
    public void ReduceHunger() {
        if (hunger > 0)
        {
            hunger -= foodDrainSpeed;
        }
        else
        {
            health -= starveDamageAmount;
        }
    }

    public void AddHunger(float amount) {
        hunger += amount;
        hunger = Mathf.Clamp(hunger, 0, 100);
    }
    #endregion

    #region health
    public void TakeDamage(float amount)
    {
        health -= amount;
    }

    public void CheckHealth()
    {
        if (!isDead)
        {
            if (health <= 0)
            {
                StartCoroutine(Die());
            }
        }
    }
    #endregion 

    #region Stamina

    public void UpdateStamina()
    {
        float amount = 0;
        PlayerStats stats = GetComponent<PlayerStats>();
        if (GetComponent<CharacterController>().velocity.magnitude > 0)
        {
            if (GetComponent<FirstPersonController>().m_IsWalking)
            {
                amount = -stats.walkingStaminaDrain;
            }
            else
            {
                amount = -stats.runningStaminaDrain;
            }
        }
        else
        {
            amount = stats.idleStaminaGain;
        }
        stamina += amount;
        stamina = Mathf.Clamp(stamina, 0, 100);
    }

    void CheckStamina() {
        if (stamina <= 0)
        {
            if (!isFatigued)
            {
                StartCoroutine(FatigueDelay());
            }
        }
        else
        {
            if (stamina <= 100)
            {
                UpdateStamina();
            }
        }
    }

    IEnumerator FatigueDelay() {
        FindObjectOfType<FirstPersonController>().speedMultiplier = fatiguedSpeedMultiplier;
        isFatigued = true;
        Debug.Log("Player is fatigued!");
        yield return new WaitForSeconds(staminaZeroDelay);
        stamina = 5f;
        isFatigued = false;
        FindObjectOfType<FirstPersonController>().speedMultiplier = 1f;
        Debug.Log("Player is no longer fatigued!");
    }
    #endregion

    #endregion

    public IEnumerator Die()
    {
        isDead = true;
        Debug.Log("Player Died!");
        FindObjectOfType<FirstPersonController>().canMove = false;

        Instantiate(playerRagdoll, transform.position, Quaternion.identity, transform);
        FindObjectOfType<ModelAnimator>().gameObject.SetActive(false);
        deadCamera.gameObject.SetActive(true);

        yield return new WaitForSeconds(respawnDelay);
        SceneManager.LoadScene(0);
        //DropInventory();
    }

    private void DropInventory()
    {
        if (Inventory.instance.items.Count > 0)
        {
            try
            {
                foreach (Item item in Inventory.instance.items)
                {
                    item.Drop();
                }
            }
            catch { }
        }
    }
}