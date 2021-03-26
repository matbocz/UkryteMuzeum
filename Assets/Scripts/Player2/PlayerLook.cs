using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLook : MonoBehaviour
{
    [Header("Mouse Sensitivity")]
    [SerializeField] float sensitivityX = 100f;
    [SerializeField] float sensitivityY = 100f;

    float mouseX;
    float mouseY;

    float xRotation = 0f;

    void Start()
    {
        HideCursor();
    }

    private static void HideCursor()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void Update()
    {
        HandleInput();

        ProcessRotation();
    }

    private void HandleInput()
    {
        mouseX = Input.GetAxis("Mouse X") * sensitivityX * Time.deltaTime;
        mouseY = Input.GetAxis("Mouse Y") * sensitivityY * Time.deltaTime;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);
    }

    private void ProcessRotation()
    {
        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        transform.parent.Rotate(Vector3.up, mouseX);
    }
}
