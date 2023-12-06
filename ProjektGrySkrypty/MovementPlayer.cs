using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementPlayer : MonoBehaviour
{
    private CharacterController controller;
    private PlayerStatistics playerStatistics;
    private Vector3 playerVelocity;
    private bool groundedPlayer;
    private float playerSpeed = 3.0f;
    private float sprintSpeedMultiplier = 2.0f;
    private float jumpHeight = 1.5f;
    private float gravityValue = -9.81f;

    void Start()
    {
        controller = GetComponent<CharacterController>();
        playerStatistics = GetComponent<PlayerStatistics>();
    }

    void Update()
    {
        if(!playerStatistics.defeat)
        {
            groundedPlayer = controller.isGrounded;
            if (groundedPlayer && playerVelocity.y < 0)
            {
                playerVelocity.y = 0f;
            }

            float movementX = Input.GetAxis("Horizontal");
            float movementZ = Input.GetAxis("Vertical");

            bool isSprinting = Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.Q);

            Vector3 movement = transform.right * movementX + transform.forward * movementZ;

            if (Input.GetButtonDown("Jump") && groundedPlayer)
            {
                playerVelocity.y += Mathf.Sqrt(jumpHeight * -3.0f * gravityValue);
            }

            float currentSpeed = isSprinting ? playerSpeed * sprintSpeedMultiplier : playerSpeed;
            controller.Move(movement * currentSpeed * Time.deltaTime);

            playerVelocity.y += gravityValue * Time.deltaTime;

            controller.Move(playerVelocity * Time.deltaTime);
        }
    }
}
