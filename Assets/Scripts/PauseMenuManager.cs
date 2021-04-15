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

    public void ResumeGame()
    {
        StartTime();
        HideCursor();

        pauseMenuPanel.SetActive(false);
        isPaused = false;
    }

    private void StartTime()
    {
        Camera.main.GetComponent<PlayerLook>().enabled = true;

        Time.timeScale = 1;
    }

    private void HideCursor()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    private void PauseGame()
    {
        StopTime();
        ShowCursor();

        pauseMenuPanel.SetActive(true);
        isPaused = true;
    }

    private void StopTime()
    {
        Camera.main.GetComponent<PlayerLook>().enabled = false;

        Time.timeScale = 0;
    }

    private void ShowCursor()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    public void QuitGame()
    {
        Application.Quit();
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
}
