using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationPlayer : MonoBehaviour
{
    private Animator animator;
    private PlayerStatistics playerStatistics;

    void Start()
    {
        animator = GetComponent<Animator>();
        playerStatistics = GetComponent<PlayerStatistics>();
    }

    void Update()
    {
        if ((Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D)) && !Input.GetKey(KeyCode.Q) && !Input.GetKey(KeyCode.Mouse0) && !playerStatistics.defeat)
        {
            animator.SetBool("IsMoving", true);
        }
        else
        {
            animator.SetBool("IsMoving", false);
        }

        if((Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.Q)) && !Input.GetKey(KeyCode.Mouse0) && !playerStatistics.defeat)
        {
            animator.SetBool("IsRunning", true);
        }
        else if ((Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.Q)) && Input.GetKey(KeyCode.Mouse0) && !playerStatistics.defeat)
        {
            animator.SetBool("IsRunning", false);
            animator.SetBool("IsAttacking", true);
        }
        else
        {
            animator.SetBool("IsRunning", false);
            animator.SetBool("IsAttacking", false);
        }

        if (Input.GetKey(KeyCode.Mouse0) && !playerStatistics.defeat)
        {
            animator.SetBool("IsAttacking", true);
        }
        else
        {
            animator.SetBool("IsAttacking", false);
        }

        if (Input.GetKey(KeyCode.Space) && !playerStatistics.defeat)
        {
            animator.SetBool("IsJumping", true);
        }
        else
        {
            animator.SetBool("IsJumping", false);
        }

        if(playerStatistics.defeat)
        {
            animator.SetTrigger("PlayerDeath");
        }
    }
}
