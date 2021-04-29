using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerLook : MonoBehaviour
{
    [Header("Mouse Sensitivity")]
    [SerializeField] private float sensitivityX = 80f;
    [SerializeField] private float sensitivityY = 80f;

    private float mouseX;
    private float mouseY;

    private float xRotation = 0f;

    private void Update()
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

    public void ChangeSensitivityX(Slider slider)
    {
        sensitivityX = slider.value;
    }

    public void ChangeSensitivityY(Slider slider)
    {
        sensitivityY = slider.value;
    }
}
