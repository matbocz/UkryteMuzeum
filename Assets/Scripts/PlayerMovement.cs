using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Movement")]
    [SerializeField] Transform orientation;
    [SerializeField] float movementSpeed = 10f;
    [SerializeField] float groundMovementMultiplier = 5f;
    [SerializeField] float airMovementMultiplier = 0.1f;

    [Header("Jumping")]
    [SerializeField] float jumpForce = 10f;

    [Header("Drag")]
    [SerializeField] float groundDrag = 5f;
    [SerializeField] float airDrag = 1f;

    [Header("Key bindings")]
    [SerializeField] KeyCode jumpKey = KeyCode.Space;

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

    private void SetIsGrounded()
    {
        isGrounded = Physics.Raycast(transform.position, Vector3.down, playerHeight / 2 + 0.1f);
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
        if (isGrounded)
        {
            rb.AddForce(moveDirection.normalized * movementSpeed * groundMovementMultiplier, ForceMode.Acceleration);
        }
        else
        {
            rb.AddForce(moveDirection.normalized * movementSpeed * groundMovementMultiplier * airMovementMultiplier, ForceMode.Acceleration);
        }
    }
}
