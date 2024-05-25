using System.Diagnostics;
/*Credit: https://github.com/dustinmorman/FPSControllerTutorial*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class FPSControl : MonoBehaviour
{
    public Camera playerCamera;
    public float walkSpeed = 3f;
    public float runSpeed = 5f;
    public float jumpPower = 5f;
    public float gravity = 10f;

    public float lookSpeed = 8f;
    public float lookXLimit = 45f;

    Vector3 moveDirection = Vector3.zero;
    float rotationX = 0;

    CharacterController characterController;

    // animation variables
    private Animator animator;
    public bool isRunning = false;
    public bool isWalking = false;
    public bool isJumping = false;


    // Start is called before the first frame update
    void Start()
    {
        characterController = GetComponent<CharacterController>();
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        //animation initialization
        animator = GetComponent<Animator>();
        if(animator == null)
        {
            UnityEngine.Debug.LogError("Animator not found\n");
        }
    }

    // Update is called once per frame
    void Update()
    {
        //Move
        Vector3 forward = transform.TransformDirection(Vector3.forward);
        Vector3 right = transform.TransformDirection(Vector3.right);

        bool isRunning = Input.GetKey(KeyCode.LeftShift);
        float curSpeedX = (isRunning ? runSpeed : walkSpeed) * Input.GetAxis("Vertical");
        float curSpeedY = (isRunning ? runSpeed : walkSpeed) * Input.GetAxis("Horizontal");
        float moveDirectionY = moveDirection.y;
        moveDirection = (forward * curSpeedX) + (right * curSpeedY);

        //animation update
        bool isWalking = (curSpeedX != 0f || curSpeedY != 0f);
        animator.SetBool("isWalking", isWalking);
        animator.SetBool("isRunning", isWalking && isRunning);

        //Jump
        if (Input.GetButton("Jump") && characterController.isGrounded)
        {
            moveDirection.y = jumpPower;
            isJumping = true;
            animator.SetBool("isJumping", isJumping);
        }
        else if (characterController.isGrounded)
        {
            isJumping = false;
            animator.SetBool("isJumping", isJumping);
        }

        else
        {
            moveDirection.y = moveDirectionY;
        }

        if(!characterController.isGrounded)
        {
            moveDirection.y -= gravity * Time.deltaTime;
        }

        //Camera
        characterController.Move(moveDirection * Time.deltaTime);
        rotationX += -Input.GetAxis("Mouse Y") * lookSpeed;
        rotationX = Mathf.Clamp(rotationX, -lookXLimit, lookXLimit);
        playerCamera.transform.localRotation = Quaternion.Euler(rotationX, 0, 0);
        transform.rotation *= Quaternion.Euler(0, Input.GetAxis("Mouse X") * lookSpeed, 0);
    }
}
