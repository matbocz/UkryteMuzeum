using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecretPickup : MonoBehaviour
{
    [Header("Panel")]
    [SerializeField] private GameObject secretPanel;

    [Header("Sound")]
    [SerializeField] private string voiceSoundName;

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

        PlayBookOpenSounds();

        GameStateManager.instance.StopGame();
    }

    private void PlayBookOpenSounds()
    {
        FindObjectOfType<AudioStateManager>().TurnDownMusic();
        FindObjectOfType<AudioStateManager>().PlaySound("BookOpen");
        FindObjectOfType<AudioStateManager>().PlaySound(voiceSoundName);
    }

    public void CloseSecretPanel()
    {
        secretPanel.SetActive(false);

        PlayBookCloseSounds();

        TutorialStateManager.instance.ShowActiveTutorialOverlays();
        GameStateManager.instance.StartGame();
    }

    private void PlayBookCloseSounds()
    {
        FindObjectOfType<AudioStateManager>().TurnUpMusic();
        FindObjectOfType<AudioStateManager>().PlaySound("BookClose");
        FindObjectOfType<AudioStateManager>().StopSound(voiceSoundName);
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
