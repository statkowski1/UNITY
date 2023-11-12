using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zad2 : MonoBehaviour
{
    public float delay = 3.0f;
    public Vector3 distance = new Vector3(0, 0, -20);

    private bool isPlayerClose = false;
    private float delayTmp = 0.0f;
    private Vector3 startPosition;

    void Start()
    {
        startPosition = transform.position;
    }

    void Update()
    {
        if (isPlayerClose)
        {
            if (delayTmp < delay)
            {
                delayTmp += Time.deltaTime;

                float tmp = delayTmp / delay;
                transform.position = Vector3.Lerp(startPosition, startPosition + distance, tmp);
            }
        }
        else
        {
            if (delayTmp > 0)
            {
                delayTmp -= Time.deltaTime;

                float tmp = delayTmp / delay;
                transform.position = Vector3.Lerp(startPosition, startPosition + distance, tmp);
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerClose = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerClose = false;
        }
    }
}
