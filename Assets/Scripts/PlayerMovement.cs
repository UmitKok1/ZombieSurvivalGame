using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Character Controller")]
    [SerializeField] private CharacterController controller;

    [Header("Character Variables")]
    [SerializeField] private float jumpHeight = 3f;
    [SerializeField] private float sprintSpeed = 18f;
    [SerializeField] private float normalSpeed = 9f;
    [SerializeField] private float crouchingSpeed = 4.5f;
    [SerializeField] private float crouchingHeight = 1.25f;
    [SerializeField] private float timeToCrouch = 0.25f;

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
    Vector3 crouchingCenter = new Vector3(0f, 0.5f, 0f);
    Vector3 standingCenter = new Vector3(0f, 0f, 0f);

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
            speed = sprintSpeed;
        }
        //Sprint to walk
        if (Input.GetKeyUp(KeyCode.LeftShift) && isGrounded)
        {
            speed = normalSpeed;
        }

        //Crouching
        if (Input.GetKeyDown(KeyCode.LeftControl) && isGrounded)
        {
            isCrouching = true;
            speed = crouchingSpeed;
            controller.height = crouchingHeight;
            controller.center = crouchingCenter;
            Debug.Log("Crouch :" + controller.center);
        }
        //Crouch to walk 
        if (Input.GetKeyUp(KeyCode.LeftControl) && controller.height == crouchingHeight)
        {
            isCrouching = false;
            speed = normalSpeed;
            StartCoroutine(StandRoutine());
            Debug.Log("Stand :" + controller.center);
        }
        x = Input.GetAxis("Horizontal");
        z = Input.GetAxis("Vertical");
        move = transform.right * x + transform.forward * z;
        controller.Move(move * speed * Time.deltaTime);
        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
    }
    IEnumerator StandRoutine()
    {
        float timeElapse = 0f;
        Vector3 currentCenter = controller.center;
        while (timeElapse < timeToCrouch)
        {
            controller.height = Mathf.Lerp(crouchingHeight, standingHeight, timeElapse / timeToCrouch);
            controller.center = Vector3.Lerp(currentCenter, standingCenter, timeElapse / timeToCrouch);
            timeElapse += Time.deltaTime;

            yield return null;

        }
        controller.height = standingHeight;
        controller.center = standingCenter;
    }
}
