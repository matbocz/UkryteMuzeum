using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecretPickup : MonoBehaviour
{
    [Header("Panel")]
    [SerializeField] private GameObject secretPanel;

    [Header("Password (only for Hidden Secrets)")]
    [SerializeField] private char character1;
    [SerializeField] private int index1;

    [Space(10)]
    [SerializeField] private char character2;
    [SerializeField] private int index2;

    private bool isFound = false;

    private void Start()
    {
        secretPanel.SetActive(false);
    }

    public void OpenSecretPanel()
    {
        secretPanel.SetActive(true);

        GameStateManager.instance.StopGame();
    }

    public void CloseSecretPanel()
    {
        secretPanel.SetActive(false);

        TutorialStateManager.instance.ShowActiveTutorialOverlays();
        GameStateManager.instance.StartGame();
    }

    public void FindSecret()
    {
        if (isFound == false)
        {
            HiddenSecretsManager.instance.AddSecretFound();

            HiddenSecretsManager.instance.AddPasswordElement(character1, index1);
            HiddenSecretsManager.instance.AddPasswordElement(character2, index2);

            isFound = true;
        }
    }
}
