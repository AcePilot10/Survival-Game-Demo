using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour {

    public float health;
    public float hunger;
    public float stamina;

    public float staminaRegenSpeed;
    public float staminaZeroDelay;

    public float foodDrainSpeed;

    private bool isFatigued = false;

    private void Update()
    {
        CheckStamina();
        ReduceHunger();
    }

    #region hunger
    public void ReduceHunger() {
        if(hunger > 0)
        {
            hunger -= foodDrainSpeed;
        }
    }
    #endregion

    #region health
    public void TakeDamage(float amount)
    {
        health -= amount;
    }
    #endregion 

    #region Stamina

    public void ReduceStamina(float amount)
    {
        stamina -= amount;
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
                stamina += Time.deltaTime * staminaRegenSpeed;
            }
        }
    }


    IEnumerator FatigueDelay() {
        isFatigued = true;
        yield return new WaitForSeconds(staminaZeroDelay);
        isFatigued = false;
    }
    #endregion
}