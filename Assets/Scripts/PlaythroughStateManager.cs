using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaythroughStateManager : MonoBehaviour
{
    void Start()
    {
        GameStateManager.instance.StartTime();
        GameStateManager.instance.HideCursor();
    }
}
