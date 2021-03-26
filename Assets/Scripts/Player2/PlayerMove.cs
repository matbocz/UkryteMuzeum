using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    [Header("Movement")]
    [SerializeField] float speed = 4f;
    [SerializeField] float sprintMultiplier = 2f;
    [SerializeField] float gravity = -10f;

    [Header("Ground detection")]
    [SerializeField] Transform groundCheck;
    [SerializeField] LayerMask groundMask;
    [SerializeField] float groundDistance = 0.5f;

    [Header("Key bindings")]
    [SerializeField] KeyCode sprintKey = KeyCode.LeftShift;

    float x;
    float z;

    bool isGrounded;

    CharacterController characterController;

    Vector3 moveDirection;
    Vector3 velocity;

    void Start()
    {
        SetCharacterController();
    }

    private void SetCharacterController()
    {
        characterController = gameObject.GetComponent(typeof(CharacterController)) as CharacterController;
    }

    void Update()
    {
        DetectGround();

        HandleInput();

        ApplyMovement();

        ApplyVelocity();
    }

    private void DetectGround()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }
    }

    private void HandleInput()
    {
        x = Input.GetAxis("Horizontal");
        z = Input.GetAxis("Vertical");
    }

    private void ApplyMovement()
    {
        moveDirection = transform.right * x + transform.forward * z;

        if (Input.GetKey(sprintKey))
        {
            characterController.Move(moveDirection * speed * sprintMultiplier * Time.deltaTime);
        }
        else
        {
            characterController.Move(moveDirection * speed * Time.deltaTime);
        }

    }

    private void ApplyVelocity()
    {
        velocity.y += gravity * Time.deltaTime;
        characterController.Move(velocity * Time.deltaTime);
    }
}
