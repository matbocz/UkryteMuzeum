using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pointer : MonoBehaviour
{
    [SerializeField] float range = 100f;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Point();
        }
    }

    private void Point()
    {
        RaycastHit hit;

        var raycast = Camera.main.ScreenPointToRay(Input.mousePosition);

        Physics.Raycast(raycast, out hit, range);
        if(hit.transform != null)
        {
            Debug.Log("Name: " + hit.transform.name + "\nTag: " + hit.transform.tag);

            if (hit.transform.tag == "MuseumSecret")
            {
                SecretPickup secretPickup = hit.transform.GetComponent<SecretPickup>();
                secretPickup.OpenSecretPanel();
            }
        }
    }
}
