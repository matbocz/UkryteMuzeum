using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameCubeEnd : MonoBehaviour
{
    Animator gameCube;

    private void OnTriggerEnter(Collider other)
    {
        gameCube.SetBool("isEnd", true);
    }

    private void Start()
    {
        gameCube = this.transform.parent.GetComponent<Animator>();
    }
}
