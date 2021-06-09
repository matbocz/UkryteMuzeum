using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HiddenSecretsManager : MonoBehaviour
{
    [Header("Text")]
    [SerializeField] public Text secretsFoundOverlay;
    [SerializeField] public Text passwordOverlay;
    [SerializeField] public Text backToMuseumOverlay;

    [Space(10)]
    [SerializeField] private TextMeshProUGUI passwordWorldText;

    private int secretsFound = 0;

    private char[] password = new char[11];

    public static HiddenSecretsManager instance;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        InitializePassword();
    }

    private void InitializePassword()
    {
        for (int i = 0; i < password.Length; i++)
        {
            password[i] = '_';
        }

        password[1] = 'E';
        password[7] = 'O';
        password[10] = 'E';

        FillPassword();
    }

    private void FillPassword()
    {
        passwordOverlay.text = string.Join(" ", password);
        passwordWorldText.text = string.Join(" ", password);
    }

    public void AddPasswordElement(char character, int index)
    {
        password[index] = character;

        FillPassword();
    }

    public void AddSecretFound()
    {
        secretsFound += 1;

        secretsFoundOverlay.text = "Znalezione zabytki: " + secretsFound.ToString() + " / 4";

        if (secretsFound == 4)
        {
            ShowInfoUIText();
            TutorialStateManager.instance.ActivatePasswordClickObject();
        }
    }

    public void ShowSecretsFoundUIText()
    {
        secretsFoundOverlay.gameObject.SetActive(true);
    }

    public void CloseSecretsFoundUIText()
    {
        secretsFoundOverlay.gameObject.SetActive(false);
    }

    public void ShowPasswordUIText()
    {
        passwordOverlay.gameObject.SetActive(true);
    }

    public void ClosePasswordUIText()
    {
        passwordOverlay.gameObject.SetActive(false);
    }

    public void ShowInfoUIText()
    {
        backToMuseumOverlay.gameObject.SetActive(true);
    }

    public void CloseInfoUIText()
    {
        backToMuseumOverlay.gameObject.SetActive(false);
    }
}
