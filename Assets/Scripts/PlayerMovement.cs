using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Character Controller")]
    [SerializeField] private CharacterController controller;

    [Header("Character Variables")]
    [SerializeField] private float jumpHeight = 3f;
    [SerializeField] private float crouchingHeight = 1.25f;
    [SerializeField] private float standingHeight = 3.8f;
    [SerializeField] private float gravity = -9.81f;
    [SerializeField] private float speed;


    [Header("Ground Variables")]
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundMask;
    [SerializeField] private float groundDistance = 0.4f;

    bool isGrounded;
    bool isCrouching;
    bool isSprinting;

    Vector3 velocity;
    Vector3 move;

    float x;
    float z;


    void Update()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);
        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        // Jumping
        if (Input.GetButtonDown("Jump") && isGrounded || Input.GetButtonDown("Jump") && isCrouching)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }


        // Sprinting
        if (Input.GetKeyDown(KeyCode.LeftShift) && isGrounded)
        {
            isSprinting = true;
            speed = speed * 2;
        }
        
        if (Input.GetKeyUp(KeyCode.LeftShift) && isGrounded)
        {
            speed = speed / 2;
        }

        //Crouching
        if (Input.GetKeyDown(KeyCode.LeftControl) && isGrounded)
        {
            isCrouching = true;
            speed = speed / 2;
            controller.height = crouchingHeight;
        }

        if (Input.GetKeyUp(KeyCode.LeftControl) && controller.height == crouchingHeight)
        {
            isCrouching = false;
            speed = speed * 2;
            controller.height = standingHeight;

        }

        Debug.Log(speed);

        x = Input.GetAxis("Horizontal");
        z = Input.GetAxis("Vertical");
        move = transform.right * x + transform.forward * z;
        controller.Move(move * speed * Time.deltaTime);
        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
    }
}
