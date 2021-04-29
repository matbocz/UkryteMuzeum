using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialPickup : MonoBehaviour
{
    [Header("Panel")]
    [SerializeField] private GameObject tutorialPanel;

    void Start()
    {
        tutorialPanel.SetActive(false);
    }

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.tag == "Player")
        {
            OpenTutorialPanel();
        }
    }

    private void OpenTutorialPanel()
    {
        tutorialPanel.SetActive(true);

        GameStateManager.instance.StopTime();
        GameStateManager.instance.ShowCursor();

        GameStateManager.instance.gameIsPaused = true;
    }

    public void CloseTutorialPanel()
    {
        tutorialPanel.SetActive(false);

        GameStateManager.instance.StartTime();
        GameStateManager.instance.HideCursor();

        GameStateManager.instance.gameIsPaused = false;

        Destroy(gameObject);
    }
}
