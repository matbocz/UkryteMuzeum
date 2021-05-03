using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialStateManager : MonoBehaviour
{
    [Header("Tutorial Start")]
    [SerializeField] private GameObject tutorialPanelStart;

    //[Header("Tutorial Step 1")]
    //[SerializeField] private GameObject tutorialPanel1;
    //[SerializeField] private GameObject tutorialOverlay1;

    void Start()
    {
        OpenTutorialPanelStart();
    }

    private void OpenTutorialPanelStart()
    {
        tutorialPanelStart.SetActive(true);

        GameStateManager.instance.StopTime();
        GameStateManager.instance.ShowCursor();
        GameStateManager.instance.gameIsPaused = true;
    }

    public void CloseTutorialPanelStart()
    {
        tutorialPanelStart.SetActive(false);

        GameStateManager.instance.StartTime();
        GameStateManager.instance.HideCursor();
        GameStateManager.instance.gameIsPaused = false;
    }
}
