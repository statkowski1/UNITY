using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public float playerDmg = 10;
    private float attackCoolDown = 1.0f;
    private float lastAttackTime = 0.0f;

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Enemy") && Input.GetKey(KeyCode.Mouse0) && Time.time - lastAttackTime >= attackCoolDown)
        {
            EnemyStatistics enemyStatistics = other.gameObject.GetComponent<EnemyStatistics>();
            if (enemyStatistics != null)
            {
                enemyStatistics.TakeDmg(playerDmg);
            }
            lastAttackTime = Time.time;
        }
    }
}
