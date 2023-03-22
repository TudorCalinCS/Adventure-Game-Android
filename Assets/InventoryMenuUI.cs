using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class InventoryMenuUI : MonoBehaviour
{
    public TextMeshProUGUI currentHealthText;
    public TextMeshProUGUI maxHealthText;
    private Transform player;
    public CharacterStats playerStats;
    public TextMeshProUGUI itemDescription;
     public void Start()
    {
        //playerStats = transform.GetComponent<CharacterStats>();
    }
    public void Update()
    {
        currentHealthText.text = playerStats.currentHealth.ToString();
        maxHealthText.text = playerStats.maxHealth.ToString();
        
    }
}
