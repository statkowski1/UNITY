using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoreHp : MonoBehaviour
{
    public GameObject Player;
    public GameObject Button;
    public Text info;
    public int price;
    public int giveHp;
    private float timer = 0.0f;

    void Start()
    {
        info.text = "Menu";
    }

    void Update()
    {
        if (Time.time - timer >= 3.0f)
        {
            info.text = "Menu";
        }
    }

    public void GiveMoreHp()
    {
        PlayerStatistics playerStatistics = Player.GetComponent<PlayerStatistics>();
        if (Button != null)
        {
            if (playerStatistics.money >= price)
            {
                playerStatistics.maxHealth = playerStatistics.maxHealth + giveHp;
                playerStatistics.currentHealth = playerStatistics.currentHealth + giveHp;
                playerStatistics.playerHealthSlider.maxValue = playerStatistics.maxHealth;
                playerStatistics.playerHealthSlider.value = playerStatistics.currentHealth;
                playerStatistics.money = playerStatistics.money - price;
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
