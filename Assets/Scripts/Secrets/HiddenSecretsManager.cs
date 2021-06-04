﻿using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HiddenSecretsManager : MonoBehaviour
{
    [Header("Text")]
    [SerializeField] public Text secretsFoundUIText;
    [SerializeField] public Text passwordUIText;
    [SerializeField] public Text infoUIText;

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
        passwordUIText.text = string.Join(" ", password);
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

        secretsFoundUIText.text = "Znalezione zabytki: " + secretsFound.ToString() + " / 4";

        if (secretsFound == 4)
        {
            ShowInfoUIText();
            TutorialStateManager.instance.ActivatePasswordClickObject();
        }
    }

    public void ShowSecretsFoundUIText()
    {
        secretsFoundUIText.gameObject.SetActive(true);
    }

    public void CloseSecretsFoundUIText()
    {
        secretsFoundUIText.gameObject.SetActive(false);
    }

    public void ShowPasswordUIText()
    {
        passwordUIText.gameObject.SetActive(true);
    }

    public void ClosePasswordUIText()
    {
        passwordUIText.gameObject.SetActive(false);
    }

    public void ShowInfoUIText()
    {
        infoUIText.gameObject.SetActive(true);
    }

    public void CloseInfoUIText()
    {
        infoUIText.gameObject.SetActive(false);
    }
}