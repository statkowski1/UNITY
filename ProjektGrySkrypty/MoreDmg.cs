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
    private PlayerAttack playerAttack;
    PlayerSpawnArrow playerSpawnArrow;

    void Start()
    {
        info.text = "Menu";
    }

    void Update()
    {
        if (Time.time - timer >= 3.0f)
        {
            info.text = "Menu";
            timer = 0.0f;
        }
    }

    public void GiveMoreDmg()
    {
        PlayerStatistics playerStatistics = Player.GetComponent<PlayerStatistics>();
        if(playerStatistics.typePlayer == "Warrior")
        {
            playerAttack = Player.GetComponentInChildren<PlayerAttack>();
        }
        else if(playerStatistics.typePlayer == "Archer")
        {
            playerSpawnArrow = Player.GetComponent<PlayerSpawnArrow>();
        }
        if (Button != null)
        {
            if (playerStatistics.money >= price)
            {
                if(playerStatistics.typePlayer == "Warrior")
                {
                    playerAttack.playerDmg = playerAttack.playerDmg + dmg;
                }
                else if (playerStatistics.typePlayer == "Archer")
                {
                    playerSpawnArrow.GetComponent<PlayerSpawnArrow>().playerDmg = playerSpawnArrow.GetComponent<PlayerSpawnArrow>().playerDmg + dmg;
                }
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
