using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class PlayerHealth : MonoBehaviour
{
    
    public static PlayerHealth Instance { get; private set; }
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
   public Slider slider;
    public TextMeshProUGUI healthText; 

    public void SetMaxHealth(int health)
    {
        slider.maxValue = health;
        slider.value = health;
        UpdateHealthText(health);
    }

    public void SetHealth(int health)
    {
        slider.value = health;
        UpdateHealthText(health);
    }

    private void UpdateHealthText(int health)
    {
        healthText.text = "Player Health: " + health;
    }
}
