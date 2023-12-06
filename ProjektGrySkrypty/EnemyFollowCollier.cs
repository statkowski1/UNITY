using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFollowCollier : MonoBehaviour
{
    public float movementSpeed = 1.5f;
    internal Transform playerTransform;

    void Start()
    {
        playerTransform = null;
    }

    void Update()
    {
        
    }

    void OnTriggerStay(Collider other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            playerTransform = other.transform;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            playerTransform = null;
        }
    }
}