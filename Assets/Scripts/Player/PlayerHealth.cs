using System.Collections;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class PlayerHealth : MonoBehaviour {

    public float health;
    public float hunger;
    public float stamina;

    private bool isFatigued = false;

    #region Settings
    public float staminaZeroDelay;
    public float foodDrainSpeed;
    public float fatiguedSpeedMultiplier;
    #endregion

    private void Update()
    {
        CheckStamina();
        ReduceHunger();
    }

    #region Health Management

    #region hunger
    public void ReduceHunger() {
        if(hunger > 0)
        {
            hunger -= foodDrainSpeed;
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
}