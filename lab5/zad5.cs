using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zad5 : MonoBehaviour
{
    public float jumpPower = 10.0f;

    void Start()
    {

    }

    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            CharacterController playerController = other.GetComponent<CharacterController>();
            if (playerController != null)
            {
                playerController.Move(Vector3.up * jumpPower * 9.81f);
            }
        }
    }
}
