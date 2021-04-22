using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenuManager : MonoBehaviour
{
    [Header("Panel")]
    [SerializeField] private GameObject pauseMenuPanel;
    [SerializeField] private GameObject optionsPanel;

    private bool isPaused = false;

    private void Start()
    {
        pauseMenuPanel.SetActive(false);
        optionsPanel.SetActive(false);
    }

    private void Update()
    {
        if (isPaused == false)
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                PauseGame();
            }
        }
    }

    private void PauseGame()
    {
        GameStateManager.instance.StopTime();
        GameStateManager.instance.ShowCursor();

        pauseMenuPanel.SetActive(true);
        isPaused = true;
    }

    public void ResumeGame()
    {
        GameStateManager.instance.StartTime();
        GameStateManager.instance.HideCursor();

        pauseMenuPanel.SetActive(false);
        isPaused = false;
    }

    public void OpenOptions()
    {
        pauseMenuPanel.SetActive(false);
        optionsPanel.SetActive(true);
    }

    public void CloseOptions()
    {
        pauseMenuPanel.SetActive(true);
        optionsPanel.SetActive(false);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
