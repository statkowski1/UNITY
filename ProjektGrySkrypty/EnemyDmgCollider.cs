using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDmgCollider : MonoBehaviour
{
    private EnemyStatistics enemyStatistics;
    private float attackCoolDown = 1.5f;
    private float lastAttackTime = 0.0f;
    internal bool playerDetect = false;

    void Start()
    {
        enemyStatistics = GetComponentInParent<EnemyStatistics>();
    }

    void Update()
    {
        
    }

    void OnTriggerStay(Collider other)
    {
        if (!enemyStatistics.enemyDeath && other.gameObject.CompareTag("Player") && Time.time - lastAttackTime >= attackCoolDown)
        {
            playerDetect = true;
            PlayerStatistics playerStatistics = other.gameObject.GetComponent<PlayerStatistics>();
            if (playerStatistics != null)
            {
                playerStatistics.TakeDmg(enemyStatistics.enemyDmg);
            }
            lastAttackTime = Time.time;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            playerDetect = false;
        }
    }
}
