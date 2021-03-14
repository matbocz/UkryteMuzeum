using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLooking : MonoBehaviour
{
    [Header("Looking")]
    [SerializeField] Transform orientation;
    [SerializeField] Transform cameraHolder;
    [SerializeField] float sensitivityX = 60f;
    [SerializeField] float sensitivityY = 60f;
    [SerializeField] float rotationMultiplier = 0.02f;

    float mouseX;
    float mouseY;

    float xRotation;
    float yRotation;

    private void Start()
    {
        CursorSetup();
    }

    private void CursorSetup()
    {
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
        cameraHolder.transform.rotation = Quaternion.Euler(xRotation, yRotation, 0);
        orientation.transform.rotation = Quaternion.Euler(0, yRotation, 0);
    }
}
