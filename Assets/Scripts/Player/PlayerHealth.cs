using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour {

    public float health;
    public float stamina;

    public float staminaRegenSpeed;
    public float staminaZeroDelay;

    private bool isFatigued = false;

    public void TakeDamage(float amount) {
        health -= amount;
    }

    public void ReduceStamina(float amount) {
        stamina -= amount;
    }

    private void Update()
    {
        CheckStamina();    
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
}