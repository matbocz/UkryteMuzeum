using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseMenuManager : MonoBehaviour
{
    [Header("Panels")]
    [SerializeField] private GameObject pausePanel;
    [SerializeField] private GameObject optionsPanel;
    [SerializeField] private GameObject mouseOptionsPanel;
    [SerializeField] private GameObject movementOptionsPanel;
    [SerializeField] private GameObject controlOptionsPanel;
    [SerializeField] private GameObject confirmationPanel;

    [Header("Texts")]
    [SerializeField] private Text secretsFoundText;
    [SerializeField] private Text descriptionsReadText;
    [SerializeField] private Text passwordText;

    private void Start()
    {
        CloseAllPanels();
    }

    private void Update()
    {
        if (GameStateManager.instance.gameIsPaused == false)
        {
            HandleMenuButtonDown();
        }
    }

    private void HandleMenuButtonDown()
    {
        if (Input.GetButtonDown("Menu"))
        {
            GameStateManager.instance.PauseGame();

            ShowPausePanel();
        }
    }

    public void ResumeGame()
    {
        GameStateManager.instance.ResumeGame();

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


        descriptionsReadText.text = AllSecretsManager.instance.descriptionsReadString;
        secretsFoundText.text = HiddenSecretsManager.instance.secretsFoundOverlay.text;
        passwordText.text = HiddenSecretsManager.instance.passwordOverlay.text;
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
