using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Spawner : MonoBehaviour
{
    public GameObject Monster;
    public GameObject Player;
    public Text WaveText;
    public int wave = 0;
    public int spawnedMonster = 3;
    private int quantity = 0;
    public float spawnAreaSize = 10f;
    public float delay = 10.0f;
    private float timer = 0.0f;
    private float timer2 = 0.0f;
    private EnemyStatistics enemyStatistics;
    private PlayerStatistics playerStatistics;

    void Start()
    {
        enemyStatistics = Monster.GetComponent<EnemyStatistics>();
        playerStatistics = Player.GetComponent<PlayerStatistics>();
        enemyStatistics.maxHealth = 100;
        enemyStatistics.enemyDmg = 5;
    }

    void Update()
    {
        if(!playerStatistics.defeat)
        {
            if (Time.time - timer >= delay)
            {
                Vector3 randomPosition = new Vector3(Random.Range(-spawnAreaSize, spawnAreaSize), 0f, Random.Range(-spawnAreaSize, spawnAreaSize));
                Instantiate(Monster, randomPosition, Quaternion.identity);
                quantity = quantity + 1;
                timer = Time.time;
            }

            if (quantity >= spawnedMonster)
            {
                wave = wave + 1;
                quantity = 0;
                enemyStatistics.maxHealth = enemyStatistics.maxHealth + 10;
                enemyStatistics.enemyDmg = enemyStatistics.enemyDmg + 1;
                WaveText.text = "Fala " + wave;
                timer2 = Time.time;
            }
            if (Time.time - timer2 >= 3.0f)
            {
                WaveText.text = "";
            }
        }
    }
}
