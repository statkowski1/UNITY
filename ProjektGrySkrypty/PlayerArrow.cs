using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerArrow : MonoBehaviour
{
    public float arrowSpeed = 10f;
    private float spawnedTime = 0.0f;
    private PlayerSpawnArrow playerSpawnArrow;

    void Start()
    {
        playerSpawnArrow = GetComponentInParent<PlayerSpawnArrow>();
        GetComponent<Rigidbody>().velocity = transform.forward * arrowSpeed;
        spawnedTime = Time.time;
    }

    void Update()
    {
        GetComponent<Rigidbody>().velocity = transform.forward * arrowSpeed;
        GetComponent<Rigidbody>().useGravity = true;
        if (Time.time - spawnedTime >= 5.0f)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Enemy"))
        {
            EnemyStatistics enemyStatistics = other.gameObject.GetComponent<EnemyStatistics>();
            if (enemyStatistics != null)
            {
                enemyStatistics.TakeDmg(playerSpawnArrow.playerDmg);
            }
            Destroy(gameObject);
        }
    }
}
