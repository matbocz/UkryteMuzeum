using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenuManager : MonoBehaviour
{
    [Header("Panel")]
    [SerializeField] private GameObject pauseMenuPanel;
    [SerializeField] private GameObject optionsPanel;

    private void Start()
    {
        pauseMenuPanel.SetActive(false);
        optionsPanel.SetActive(false);
    }

    private void Update()
    {
        if (GameStateManager.instance.gameIsPaused == false)
        {
            HandleEscapeKeyDown();
        }
    }

    private void HandleEscapeKeyDown()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            PauseGame();
        }
    }

    private void PauseGame()
    {
        GameStateManager.instance.StopTime();
        GameStateManager.instance.ShowCursor();
        GameStateManager.instance.gameIsPaused = true;

        pauseMenuPanel.SetActive(true);
    }

    public void ResumeGame()
    {
        GameStateManager.instance.StartTime();
        GameStateManager.instance.HideCursor();
        GameStateManager.instance.gameIsPaused = false;

        pauseMenuPanel.SetActive(false);
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
