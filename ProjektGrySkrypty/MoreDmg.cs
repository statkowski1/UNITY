using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoreDmg : MonoBehaviour
{
    public GameObject Player;
    public GameObject Button;
    public Text info;
    public int price;
    public int dmg;
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

    public void GiveMoreDmg()
    {
        PlayerStatistics playerStatistics = Player.GetComponent<PlayerStatistics>();
        PlayerAttack playerAttack = Player.GetComponentInChildren<PlayerAttack>();
        if (Button != null)
        {
            if (playerStatistics.money >= price)
            {
                playerAttack.playerDmg = playerAttack.playerDmg + dmg;
                playerStatistics.money = playerStatistics.money - price;
                playerStatistics.playerCoinsText.text = playerStatistics.money.ToString();
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
