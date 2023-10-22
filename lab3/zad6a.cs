using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class zad5 : MonoBehaviour
{
    //Celem programu jest korekta hamowania i przyspieszania, aby obiekt nie poruszał się sztywno z tą samą prędkością, a przyspieszał do maksymalnej prędkości i powoli ją wytracał
    public float maxSpeed = 10f;
    public float accelerationTime = 1f;
    private float currentSpeedX = 0f;
    private float currentSpeedZ = 0f;
    private float velocityX = 0f;
    private float velocityZ = 0f;

    void Start()
    {
        
    }

    void Update()
    {
        float targetSpeedX = Input.GetAxis("Horizontal") * maxSpeed;
        float targetSpeedZ = Input.GetAxis("Vertical") * maxSpeed;
        currentSpeedX = Mathf.SmoothDamp(currentSpeedX, targetSpeedX, ref velocityX, accelerationTime);
        currentSpeedZ = Mathf.SmoothDamp(currentSpeedZ, targetSpeedZ, ref velocityZ, accelerationTime);
        Vector3 movement = new Vector3(currentSpeedX, 0f, currentSpeedZ);
        transform.Translate(movement * Time.deltaTime);
    }
}
