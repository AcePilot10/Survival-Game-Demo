using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour {

    public float entityAttackStrength;
    public float interactableReach = 10;
    public float entityReach = 7;
    public float fistStrength = 5f;
    public float fistKnockback = 5f;
    public float walkingStaminaDrain;
    public float runningStaminaDrain;
    public float idleStaminaGain;

    public void SetAttackStrength(float amount) {
        entityAttackStrength = amount;
    }

    public void SetAttackStrengthToFist() {
        entityAttackStrength = fistStrength;
    }
}