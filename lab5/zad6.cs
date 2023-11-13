using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zad6 : MonoBehaviour
{
    
    void Start()
    {
        
    }

    void Update()
    {
        
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Hindrance"))
        {
            Debug.Log("Doszło do kontaktu z przeszkodą!");
        }
    }
}
