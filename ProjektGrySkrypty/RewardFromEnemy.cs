using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RewardFromEnemy : MonoBehaviour
{
    public int rewardMoney = 80;
    public int rewardExp = 3500;
    private EnemyStatistics enemyStatistics;
    private bool rewarded = false;
    private bool death = false;
    void Start()
    {
        enemyStatistics = GetComponentInParent<EnemyStatistics>();
    }

    void Update()
    {
        death = enemyStatistics.enemyDeath;
    }

    void OnTriggerStay(Collider other)
    {
        if(other.gameObject.CompareTag("Player") && death && !rewarded)
        {
            PlayerStatistics playerStatistics = other.gameObject.GetComponent<PlayerStatistics>();
            if (playerStatistics != null)
            {
                playerStatistics.GetReward(rewardMoney, rewardExp);
                rewarded = true;
            }
        }
    }
}
