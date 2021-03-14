using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Movement")]
    [SerializeField] Transform orientation;[Space(10)]
    [SerializeField] float movementSpeed = 10f;[Space(10)]
    [SerializeField] float groundMovementMultiplier = 2f;
    [SerializeField] float airMovementMultiplier = 0.2f;[Space(10)]
    [SerializeField] float accelerationMultiplier = 2f;

    [Header("Jumping")]
    [SerializeField] float jumpForce = 6f;

    [Header("Drag")]
    [SerializeField] float groundDrag = 4f;
    [SerializeField] float airDrag = 0.4f;

    [Header("Key bindings")]
    [SerializeField] KeyCode jumpKey = KeyCode.Space;
    [SerializeField] KeyCode accelerateKey = KeyCode.LeftShift;

    readonly float playerHeight = 2f;

    float horizontalMove;
    float verticalMove;

    bool isGrounded;

    Vector3 moveDirection;

    Rigidbody rb;

    private void Start()
    {
        RigidbodySetup();
    }

    private void RigidbodySetup()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;
    }

    private void Update()
    {
        SetIsGrounded();

        MyInput();

        ControlDrag();

        if (Input.GetKeyDown(jumpKey) && isGrounded)
        {
            Jump();
        }
    }

    private void SetIsGrounded()
    {
        isGrounded = Physics.Raycast(transform.position, Vector3.down, playerHeight / 2 + 0.1f);
    }

    private void MyInput()
    {
        horizontalMove = Input.GetAxisRaw("Horizontal");
        verticalMove = Input.GetAxisRaw("Vertical");

        moveDirection = orientation.forward * verticalMove + orientation.right * horizontalMove;
    }

    private void ControlDrag()
    {
        if (isGrounded)
        {
            rb.drag = groundDrag;
        }
        else
        {
            rb.drag = airDrag;
        }
    }

    private void Jump()
    {
        rb.AddForce(transform.up * jumpForce, ForceMode.Impulse);
    }

    private void FixedUpdate()
    {
        MovePlayer();
    }

    private void MovePlayer()
    {
        if (isGrounded && Input.GetKey(accelerateKey))
        {
            rb.AddForce(moveDirection.normalized * movementSpeed * groundMovementMultiplier * accelerationMultiplier, ForceMode.Acceleration);
        }
        else if (isGrounded)
        {
            rb.AddForce(moveDirection.normalized * movementSpeed * groundMovementMultiplier, ForceMode.Acceleration);
        }
        else
        {
            rb.AddForce(moveDirection.normalized * movementSpeed * groundMovementMultiplier * airMovementMultiplier, ForceMode.Acceleration);
        }
    }
}
