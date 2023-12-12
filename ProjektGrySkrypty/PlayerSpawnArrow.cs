using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpawnArrow : MonoBehaviour
{
    public GameObject Arrow;
    public float playerDmg = 10;
    private float attackCoolDown = 1.0f;
    private float lastAttackTime = 0.0f;

    void Start()
    {
        
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.Mouse0) && Time.time - lastAttackTime >= attackCoolDown)
        {
            Vector3 PlayerPosition = transform.position;
            PlayerPosition.y = PlayerPosition.y + 1.0f;
            Quaternion playerRotation = Quaternion.Euler(0, transform.eulerAngles.y, 0);
            GameObject arrow = Instantiate(Arrow, PlayerPosition, playerRotation, transform);
            lastAttackTime = Time.time;
        }
    }
}