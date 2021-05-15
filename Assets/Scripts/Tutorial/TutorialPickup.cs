using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialPickup : MonoBehaviour
{
    [Header("Panel")]
    [SerializeField] private GameObject tutorialPanel;

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.tag == "Player")
        {
            OpenTutorialPanel();
            Destroy(gameObject);

            TutorialStateManager.instance.HideActiveTutorialOverlays();
            GameStateManager.instance.StopGame();
        }
    }

    private void OpenTutorialPanel()
    {
        tutorialPanel.SetActive(true);
    }
}
