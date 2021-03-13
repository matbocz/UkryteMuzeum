using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLooking : MonoBehaviour
{
    [Header("Looking")]
    [SerializeField] float sensitivityX = 60f;
    [SerializeField] float sensitivityY = 60f;
    [SerializeField] float rotationMultiplier = 0.02f;

    Camera cam;

    float mouseX;
    float mouseY;

    float xRotation;
    float yRotation;

    private void Start()
    {
        CameraSetup();
    }

    private void CameraSetup()
    {
        cam = GetComponentInChildren<Camera>();

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    private void Update()
    {
        MyInput();
        ProcessRotation();
    }

    private void MyInput()
    {
        mouseX = Input.GetAxisRaw("Mouse X");
        mouseY = Input.GetAxisRaw("Mouse Y");

        yRotation += mouseX * sensitivityX * rotationMultiplier;
        xRotation -= mouseY * sensitivityY * rotationMultiplier;

        xRotation = Mathf.Clamp(xRotation, -90f, 90f);
    }

    private void ProcessRotation()
    {
        cam.transform.localRotation = Quaternion.Euler(xRotation, 0, 0);
        transform.rotation = Quaternion.Euler(0, yRotation, 0);
    }
}
