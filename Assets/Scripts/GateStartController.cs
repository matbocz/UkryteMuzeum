using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GateStartController : MonoBehaviour
{
    Animator gateStart;

    private void OnTriggerEnter(Collider other)
    {
        gateStart.SetBool("isOpening", true);
    }

    private void OnTriggerExit(Collider other)
    {
        gateStart.SetBool("isOpening", false);
    }

    private void Start()
    {
        gateStart = this.transform.parent.GetComponent<Animator>();
    }
}
