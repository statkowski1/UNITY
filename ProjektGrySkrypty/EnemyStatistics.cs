using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyStatistics : MonoBehaviour
{
    public Canvas enemyCanvas;
    public Slider enemyHealthSlider;
    public Text enemyHealthText;
    public float enemyDmg = 5;
    public float maxHealth = 100;
    public float currentHealth;
    internal bool enemyDeath = false;

    void Start()
    {
        currentHealth = maxHealth;
        enemyHealthSlider.minValue = 0;
        enemyHealthSlider.maxValue = maxHealth;
        enemyHealthSlider.value = currentHealth;
        enemyHealthText.text = currentHealth + "/" + maxHealth;
    }

    void Update()
    {
        
    }

    internal void TakeDmg(float dmg)
    {
        currentHealth = currentHealth - dmg;
        enemyHealthSlider.value = currentHealth;
        enemyHealthText.text = currentHealth + "/" + maxHealth;
        if (currentHealth <= 0)
        {
            enemyDeath = true;
        }
    }
}
