using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementCamera : MonoBehaviour
{
    public Transform player;
    private bool isCursorLocked = false;
    public float sensitivity = 200f;
    public float maxYRotation = 90f;
    public float minYRotation = -90f;
    private float rotationX = 0f;

    void Start()
    {
        //Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        float mouseXMove = Input.GetAxis("Mouse X") * sensitivity * Time.deltaTime;
        float mouseYMove = Input.GetAxis("Mouse Y") * sensitivity * Time.deltaTime;

        rotationX -= mouseYMove;
        rotationX = Mathf.Clamp(rotationX, minYRotation, maxYRotation);

        player.Rotate(Vector3.up * mouseXMove);
        transform.localRotation = Quaternion.Euler(rotationX, 0f, 0f);

        if (isCursorLocked && Input.GetKeyDown(KeyCode.L))
        {
            Cursor.lockState = CursorLockMode.Locked;
            isCursorLocked = !isCursorLocked;
        }
        else if(!isCursorLocked && Input.GetKeyDown(KeyCode.L))
        {
            Cursor.lockState = CursorLockMode.None;
            isCursorLocked = !isCursorLocked;
        }
    }
}
