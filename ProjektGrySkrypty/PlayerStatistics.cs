using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStatistics : MonoBehaviour
{
    public Canvas playerCanvas;
    public Slider playerHealthSlider;
    public Text playerHealthText;
    public Slider playerExpSlider;
    public Text playerExpText;
    public Text playerLvlText;
    public Text playerCoinsText;
    public Text DefeatText;
    public float maxHealth = 100;
    public float currentHealth;
    public int money = 0;
    public int exp = 0;
    public int lvl = 0;
    public int nextLvlExp = 200;
    public bool defeat = false;
    private PlayerAttack playerAttack;

    void Start()
    {
        playerAttack = GetComponentInChildren<PlayerAttack>();
        currentHealth = maxHealth;
        playerHealthSlider.minValue = 0;
        playerHealthSlider.maxValue = maxHealth;
        playerHealthSlider.value = currentHealth;
        playerHealthText.text = currentHealth + "/" + maxHealth;
        playerExpSlider.minValue = 0;
        playerExpSlider.maxValue = nextLvlExp;
        playerExpSlider.value = exp;
        playerExpText.text = exp + "/" + nextLvlExp;
        playerLvlText.text = lvl.ToString();
        playerCoinsText.text = money.ToString();
    }

    void Update()
    {
        if(currentHealth <= 0)
        {
            defeat = true;
            DefeatText.text = "Przegra³eœ!";
            playerAttack.playerDmg = 0;
        }
    }

    internal void TakeDmg(float dmg)
    {
        currentHealth = currentHealth - dmg;
        playerHealthSlider.value = currentHealth;
        playerHealthText.text = currentHealth + "/" + maxHealth;
    }

    internal void GetReward(int droppedMoney, int droppedExp)
    {
        money = money + droppedMoney;
        exp = exp + droppedExp;
        while(exp >= nextLvlExp)
        {
            lvl = lvl + 1;
            exp = exp - nextLvlExp;
            nextLvlExp = nextLvlExp + 100 * lvl;
            currentHealth = currentHealth + 10;
            maxHealth = maxHealth + 10;
        }
        playerHealthSlider.maxValue = maxHealth;
        playerHealthSlider.value = currentHealth;
        playerHealthText.text = currentHealth + "/" + maxHealth;
        playerExpSlider.maxValue = nextLvlExp;
        playerExpSlider.value = exp;
        playerExpText.text = exp + "/" + nextLvlExp;
        playerLvlText.text = lvl.ToString();
        playerCoinsText.text = money.ToString();
    }
}
