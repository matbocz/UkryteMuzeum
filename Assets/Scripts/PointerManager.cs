using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PointerManager : MonoBehaviour
{
    [Header("Pointer")]
    [SerializeField] private Image pointerImage;
    [SerializeField] private Sprite defaultPointer;
    [SerializeField] private Sprite selectPointer;

    [Space(10)]
    [SerializeField] private Vector3 defaultPointerScale = new Vector3(1f, 1f, 1f);
    [SerializeField] private Vector3 selectPointerScale = new Vector3(2f, 2f, 2f);

    [Header("Raycast")]
    [SerializeField] private float raycastRange = 2f;

    RaycastHit raycastHit;

    private void Update()
    {
        SetRaycast();

        if (raycastHit.transform != null)
        {
            if (raycastHit.transform.tag == "MuseumSecret" || raycastHit.transform.tag == "HiddenSecret" || raycastHit.transform.tag == "StartQuiz")
            {
                SetSelectPointer();

                if (Input.GetMouseButtonDown(0))
                {
                    Click();
                }
            }
        }
        else
        {
            SetDefaultPointer();
        }
    }

    private void SetRaycast()
    {
        Ray raycast = Camera.main.ScreenPointToRay(Input.mousePosition);
        Physics.Raycast(raycast, out raycastHit, raycastRange);
    }

    private void SetSelectPointer()
    {

        pointerImage.sprite = selectPointer;
        pointerImage.transform.localScale = selectPointerScale;
    }

    private void Click()
    {
        Debug.Log("Name: " + raycastHit.transform.name + "\nTag: " + raycastHit.transform.tag);

        if (raycastHit.transform.tag == "MuseumSecret")
        {
            SecretPickup secretPickup = raycastHit.transform.GetComponent<SecretPickup>();
            secretPickup.OpenSecretPanel();
        }
        else if (raycastHit.transform.tag == "HiddenSecret")
        {
            SecretPickup secretPickup = raycastHit.transform.GetComponent<SecretPickup>();
            secretPickup.FindSecret();
            secretPickup.OpenSecretPanel();
        }
        else if (raycastHit.transform.tag == "StartQuiz")
        {
            SceneManager.LoadScene(1);
        }
    }

    private void SetDefaultPointer()
    {
        pointerImage.sprite = defaultPointer;
        pointerImage.transform.localScale = defaultPointerScale;
    }
}
