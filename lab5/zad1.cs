using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zad1 : MonoBehaviour
{
    public Vector3 endPoint = new Vector3(0, 0, 10);
    public float travelTime = 5.0f;

    private Rigidbody _rigidbody;
    private Vector3 startPoint;
    private Vector3 currentPosition;
    private bool playerOnPlatform = false;
    CharacterController player1;

    void Start()
    {
        startPoint = transform.position;
        _rigidbody = GetComponent<Rigidbody>();
        _rigidbody.isKinematic = true;
    }

    void FixedUpdate()
    {
        if (playerOnPlatform)
        {
            currentPosition = Vector3.Lerp(startPoint, endPoint, Mathf.Cos(Time.time / travelTime * Mathf.PI * 2) * -0.5f + 0.5f);
            _rigidbody.MovePosition(currentPosition);
        }
        else if(playerOnPlatform==false && Mathf.Abs(Vector3.Distance(currentPosition, startPoint)) > 0.5f)
        {
            currentPosition = Vector3.Lerp(currentPosition, startPoint, Time.deltaTime * 2.0f);
            _rigidbody.MovePosition(currentPosition);
        }
        Debug.Log(playerOnPlatform);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            player1 = other.GetComponent<CharacterController>();
            playerOnPlatform = true;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            player1.Move(_rigidbody.velocity * Time.deltaTime);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerOnPlatform = false;
        }
    }
}
