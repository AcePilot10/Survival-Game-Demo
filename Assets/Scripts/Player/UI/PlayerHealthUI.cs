using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealthUI : MonoBehaviour {

    public Slider healthSlider;
    public Slider hungerSlider;
    public Slider staminaSlider;

    private PlayerHealth health;

    private void Start()
    {
        health = GameObject.FindObjectOfType<PlayerHealth>();
    }

    private void Update()
    {
        healthSlider.value = health.health;
        hungerSlider.value = health.hunger;
        staminaSlider.value = health.stamina;
    }
}