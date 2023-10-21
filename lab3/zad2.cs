using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class zad2 : MonoBehaviour
{
    public float speed = 10f;
    private bool movingForward = true;

    void Start()
    {
        
    }

    void Update()
    {
        if(movingForward)
        {
            transform.Translate(Vector3.right * speed * Time.deltaTime);
        }
        else
        {
            transform.Translate(Vector3.left * speed * Time.deltaTime);
        }

        if(Mathf.Abs(transform.position.x) >= 10)
        {
            movingForward = !movingForward;
        }
    }
}
