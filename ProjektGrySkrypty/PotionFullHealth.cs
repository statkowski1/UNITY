using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PotionFullHealth : MonoBehaviour
{
    public GameObject Player;
    public GameObject Button;
    public Text info;
    private float timer = 0.0f;

    void Start()
    {
        info.text = "Menu";
    }

    void Update()
    {
        if(Time.time - timer >= 3.0f)
        {
            info.text = "Menu";
            timer = 0.0f;
        }
    }

    public void RegenerateFullHp()
    {
        PlayerStatistics playerStatistics = Player.GetComponent<PlayerStatistics>();
        if(Button != null)
        {
            if(playerStatistics.money >= 500)
            {
                playerStatistics.currentHealth = playerStatistics.maxHealth;
                playerStatistics.money = playerStatistics.money - 500;
                playerStatistics.playerCoinsText.text = playerStatistics.money.ToString();
                playerStatistics.playerHealthSlider.value = playerStatistics.currentHealth;
                playerStatistics.playerHealthText.text = playerStatistics.currentHealth + "/" + playerStatistics.maxHealth;
                info.text = "Dokonano zakupu!";
                timer = Time.time;

            }
            else
            {
                info.text = "Brak wystarczaj¹cych œrodków";
                timer = Time.time;
            }
        }
    }
}
