using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartMenuManager : MonoBehaviour
{
    [Header("Panels")]
    [SerializeField] private GameObject startPanel;
    [SerializeField] private GameObject instructionsPanel;

    private void Start()
    {
        GameStateManager.instance.ShowCursor();

        startPanel.SetActive(true);
        instructionsPanel.SetActive(false);
    }

    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }

    public void ShowInstructionsPanel()
    {
        startPanel.SetActive(false);
        instructionsPanel.SetActive(true);
    }

    public void CloseInstructionsPanel()
    {
        startPanel.SetActive(true);
        instructionsPanel.SetActive(false);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
