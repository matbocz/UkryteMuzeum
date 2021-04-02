using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PointerManager : MonoBehaviour
{
    [Header("Pointer")]
    [SerializeField] Image pointerImage;
    [SerializeField] Sprite defaultPointer;
    [SerializeField] Sprite selectPointer;

    [Header("Raycast")]
    [SerializeField] float raycastRange = 100f;

    RaycastHit raycastHit;

    private void Update()
    {
        SetRaycast();

        if (raycastHit.transform != null)
        {
            SetPointer();

            if (Input.GetMouseButtonDown(0))
            {
                Click();
            }
        }
    }

    private void SetRaycast()
    {
        Ray raycast = Camera.main.ScreenPointToRay(Input.mousePosition);
        Physics.Raycast(raycast, out raycastHit, raycastRange);
    }

    private void SetPointer()
    {
        if (raycastHit.transform.tag == "MuseumSecret")
        {
            pointerImage.sprite = selectPointer;
        }
        else
        {
            pointerImage.sprite = defaultPointer;
        }
    }

    private void Click()
    {
        Debug.Log("Name: " + raycastHit.transform.name + "\nTag: " + raycastHit.transform.tag);

        if (raycastHit.transform.tag == "MuseumSecret")
        {
            SecretPickup secretPickup = raycastHit.transform.GetComponent<SecretPickup>();
            secretPickup.OpenSecretPanel();
        }
    }
}
