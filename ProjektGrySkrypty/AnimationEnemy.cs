using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationEnemy : MonoBehaviour
{
    private Animator animator;
    private EnemyDmgCollider enemyDmgCollider;
    private EnemyFollowCollier enemyFollowCollier;
    private EnemyStatistics enemyStatistics;
    private float deathTime = 0.0f;
    private bool isDying = false;
    void Start()
    {
        animator = GetComponent<Animator>();
        enemyDmgCollider = GetComponentInChildren<EnemyDmgCollider>();
        enemyFollowCollier = GetComponentInChildren<EnemyFollowCollier>();
        enemyStatistics = GetComponent<EnemyStatistics>();
    }

    void Update()
    {
        if(enemyDmgCollider.playerDetect && !enemyStatistics.enemyDeath)
        {
            animator.SetBool("EnemyAttack", true);
        }
        else
        {
            animator.SetBool("EnemyAttack", false);
        }

        if(enemyFollowCollier.playerTransform != null && !enemyDmgCollider.playerDetect && !enemyStatistics.enemyDeath)
        {
            animator.SetBool("EnemyRunning", true);
        }
        else
        {
            animator.SetBool("EnemyRunning", false);
        }

        if (enemyStatistics.enemyDeath && !isDying)
        {
            animator.SetTrigger("EnemyDying");
            deathTime = Time.time;
            isDying = true;
        }

        if (isDying && Time.time - deathTime >= 5.0f)
        {
            Destroy(gameObject);
        }
    }
}
