using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStateManager : MonoBehaviour
{
    public bool gameIsPaused = false;

    public static GameStateManager instance;

    private void Awake()
    {
        instance = this;
    }

    public void StartTime()
    {
        Camera.main.GetComponent<PlayerLook>().enabled = true;
        Time.timeScale = 1;
    }

    public void StopTime()
    {
        Camera.main.GetComponent<PlayerLook>().enabled = false;
        Time.timeScale = 0;
    }

    public void ShowCursor()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    public void HideCursor()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
}
