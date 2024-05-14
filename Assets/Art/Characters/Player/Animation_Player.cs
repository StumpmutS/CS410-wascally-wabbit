using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animation_Player : MonoBehaviour
{
    private Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
         // Get player input for movement
        float moveInput = Input.GetAxisRaw("Horizontal");
        bool jumpInput = Input.GetKeyDown(KeyCode.Space);

        // Set animation parameters based on player input
        if (moveInput != 0)
        {
            animator.SetBool("isWalking", true);
            animator.SetBool("isRunning", true); // You can modify this based on your logic
        }
        else
        {
            animator.SetBool("isWalking", false);
            animator.SetBool("isRunning", false);
        }

        if (jumpInput)
        {
            animator.SetBool("isJumping", true);
        }
        else
        {
            animator.SetBool("isJumping", false);
        }
    }
}
