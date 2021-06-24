using UnityEngine;
using UnityEngine.UI;

public class PlayerMove : MonoBehaviour
{
    [Header("Movement")]
    [SerializeField] private float movementSpeed = 4f;
    [SerializeField] private float sprintMultiplier = 2f;
    [SerializeField] private float gravity = -8f;

    [Header("Ground detection")]
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundMask;
    [SerializeField] private float groundDistance = 0.5f;

    [Header("Key bindings")]
    [SerializeField] private KeyCode sprintKey = KeyCode.LeftShift;

    private float x;
    private float z;

    private bool isGrounded;

    private CharacterController characterController;

    private Vector3 moveDirection;
    private Vector3 velocity;

    private void Start()
    {
        SetCharacterController();
    }

    private void SetCharacterController()
    {
        characterController = gameObject.GetComponent(typeof(CharacterController)) as CharacterController;
    }

    private void Update()
    {
        HandleInput();

        ApplyMovement();

        ApplyVelocity();

        DetectGround();
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
            characterController.Move(moveDirection * movementSpeed * sprintMultiplier * Time.deltaTime);
        }
        else
        {
            characterController.Move(moveDirection * movementSpeed * Time.deltaTime);
        }

    }

    private void ApplyVelocity()
    {
        velocity.y += gravity * Time.deltaTime;
        characterController.Move(velocity * Time.deltaTime);
    }

    private void DetectGround()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -5f;
        }
    }

    public void ChangeMovementSpeed(Slider slider)
    {
        movementSpeed = slider.value;
    }
}
