using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Soundtrack : MonoBehaviour
{
    public AudioSource audioSource;
    private bool turnOn = false;

    private void Start()
    {
        audioSource.Stop();
    }

    public void TurnOnOffSoundrack()
    {
        if(turnOn)
        {
            audioSource.Stop();
            turnOn = false;
        }
        else
        {
            audioSource.Play();
            turnOn = true;
        }
    }
}
