using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenuManager : MonoBehaviour
{
    [Header("Panels")]
    [SerializeField] private GameObject pausePanel;
    [SerializeField] private GameObject optionsPanel;
    [SerializeField] private GameObject mouseOptionsPanel;
    [SerializeField] private GameObject movementOptionsPanel;
    [SerializeField] private GameObject controlOptionsPanel;
    [SerializeField] private GameObject confirmationPanel;

    private void Start()
    {
        CloseAllPanels();
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

        ShowPausePanel();
    }

    public void ResumeGame()
    {
        GameStateManager.instance.StartTime();
        GameStateManager.instance.HideCursor();
        GameStateManager.instance.gameIsPaused = false;

        CloseAllPanels();
    }

    public void QuitToStartMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void ShowPausePanel()
    {
        CloseAllPanels();
        pausePanel.SetActive(true);
    }

    public void ShowOptionsPanel()
    {
        CloseAllPanels();
        optionsPanel.SetActive(true);
    }

    public void ShowMouseOptionsPanel()
    {
        CloseAllPanels();
        mouseOptionsPanel.SetActive(true);
    }

    public void ShowMovementOptionsPanel()
    {
        CloseAllPanels();
        movementOptionsPanel.SetActive(true);
    }

    public void ShowControlOptionsPanel()
    {
        CloseAllPanels();
        controlOptionsPanel.SetActive(true);
    }

    public void ShowConfirmationPanel()
    {
        CloseAllPanels();
        confirmationPanel.SetActive(true);
    }

    private void CloseAllPanels()
    {
        pausePanel.SetActive(false);
        optionsPanel.SetActive(false);
        mouseOptionsPanel.SetActive(false);
        movementOptionsPanel.SetActive(false);
        controlOptionsPanel.SetActive(false);
        confirmationPanel.SetActive(false);
    }
}
