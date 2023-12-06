using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    private EnemyFollowCollier enemyFollowCollier;
    private EnemyDmgCollider enemyDmgCollider;
    private EnemyStatistics enemyStatistics;

    void Start()
    {
        enemyFollowCollier = GetComponentInChildren<EnemyFollowCollier>();
        enemyDmgCollider = GetComponentInChildren<EnemyDmgCollider>();
        enemyStatistics = GetComponent<EnemyStatistics>();
    }

    void Update()
    {
        if (enemyFollowCollier.playerTransform != null && !enemyDmgCollider.playerDetect && !enemyStatistics.enemyDeath)
        {
            Vector3 directionToPlayer = enemyFollowCollier.playerTransform.position - transform.position;
            directionToPlayer.y = 0;

            transform.forward = directionToPlayer.normalized;

            transform.position += transform.forward * enemyFollowCollier.movementSpeed * Time.deltaTime;
        }
    }
}
