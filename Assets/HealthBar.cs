using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public CharacterStats playerStats;
    public Slider slider;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        slider.maxValue = playerStats.maxHealth;
        slider.value = playerStats.currentHealth;
    }
}
