using System.Collections.Generic;
using UnityEngine;

public class TutorialStateManager : MonoBehaviour
{
    [Header("Tutorial Start - Start Panel")]
    [SerializeField] private GameObject tutorialStartPanel;

    [Header("Tutorial Step 1 - Road to the muzeum")]
    [SerializeField] private GameObject tutorialPanel1;
    [SerializeField] private GameObject tutorialOverlay1;

    [Header("Tutorial Step 2 - Entrance to the museum")]
    [SerializeField] private GameObject tutorialPanel2;
    [SerializeField] private GameObject tutorialOverlay2;

    [Header("Tutorial Step 3 - Start secrets searching")]
    [SerializeField] private GameObject tutorialPanel3;
    [SerializeField] private GameObject MiniMapOverlay;
    [SerializeField] private GameObject[] lockedDoors = new GameObject[6];

    [Header("Tutorial Step 4 - End secrets searching")]
    [SerializeField] private GameObject passwordClickObject;
    [SerializeField] private GameObject passwordInfoPanel;

    [Header("Tutorial End - Start exit searching")]
    [SerializeField] private GameObject tutorialEndPanel;
    [SerializeField] private GameObject tutorialEndOverlay;
    [SerializeField] private GameObject quizDoor;

    private GameObject[] tutorialOverlays = new GameObject[6];
    private List<GameObject> activeTutorialOverlays = new List<GameObject>();

    public static TutorialStateManager instance;

    private void Awake()
    {
        CreateInstance();
    }

    private void CreateInstance()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != null)
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        OpenTutorialPanelStart();
    }

    private void OpenTutorialPanelStart()
    {
        tutorialStartPanel.SetActive(true);

        GameStateManager.instance.PauseGame();
    }

    public void CloseTutorialPanelStart()
    {
        tutorialStartPanel.SetActive(false);

        GameStateManager.instance.ResumeGame();
    }

    public void CloseTutorialPanel1()
    {
        tutorialPanel1.SetActive(false);
        tutorialOverlay1.SetActive(true);

        GameStateManager.instance.ResumeGame();
    }

    public void CloseTutorialPanel2()
    {
        tutorialPanel2.SetActive(false);
        tutorialOverlay1.SetActive(false);
        tutorialOverlay2.SetActive(true);

        GameStateManager.instance.ResumeGame();
    }

    public void CloseTutorialPanel3()
    {
        tutorialPanel3.SetActive(false);
        tutorialOverlay2.SetActive(false);
        MiniMapOverlay.SetActive(true);

        HiddenSecretsManager.instance.ShowSecretsFoundUIText();
        HiddenSecretsManager.instance.ShowPasswordUIText();

        foreach (GameObject lockedDoor in lockedDoors)
        {
            lockedDoor.SetActive(false);
        }

        GameStateManager.instance.ResumeGame();
    }

    public void ActivatePasswordClickObject()
    {
        passwordClickObject.SetActive(true);
    }

    public void OpenPasswordInfoPanel()
    {
        HiddenSecretsManager.instance.CloseSecretsFoundUIText();
        HiddenSecretsManager.instance.ClosePasswordUIText();
        HiddenSecretsManager.instance.CloseInfoUIText();

        passwordInfoPanel.SetActive(true);

        GameStateManager.instance.PauseGame();
    }

    public void OpenTutorialEndPanel()
    {
        passwordInfoPanel.SetActive(false);

        tutorialEndPanel.SetActive(true);
    }

    public void CloseTutorialEndPanel()
    {
        tutorialEndPanel.SetActive(false);

        tutorialEndOverlay.SetActive(true);
        quizDoor.SetActive(true);

        GameStateManager.instance.ResumeGame();
    }

    public void HideActiveTutorialOverlays()
    {
        GetAllTutorialOverlays();

        activeTutorialOverlays.Clear();

        foreach (GameObject tutorialOverlay in tutorialOverlays)
        {
            if (tutorialOverlay.activeSelf == true)
            {
                activeTutorialOverlays.Add(tutorialOverlay);
                tutorialOverlay.SetActive(false);
            }
        }
    }

    private void GetAllTutorialOverlays()
    {
        tutorialOverlays[0] = tutorialOverlay1;
        tutorialOverlays[1] = tutorialOverlay2;
        tutorialOverlays[2] = HiddenSecretsManager.instance.secretsFoundOverlay.gameObject;
        tutorialOverlays[3] = HiddenSecretsManager.instance.passwordOverlay.gameObject;
        tutorialOverlays[4] = HiddenSecretsManager.instance.backToMuseumOverlay.gameObject;
        tutorialOverlays[5] = tutorialEndOverlay;
    }

    public void ShowActiveTutorialOverlays()
    {
        foreach (GameObject activeTutorialOverlay in activeTutorialOverlays)
        {
            try
            {
                activeTutorialOverlay.SetActive(true);
            }
            catch
            {
                continue;
            }
        }
    }
}