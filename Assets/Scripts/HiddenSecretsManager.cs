using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HiddenSecretsManager : MonoBehaviour
{
    [Header("Text")]
    [SerializeField] private TextMeshProUGUI secretsFoundText;
    [SerializeField] private TextMeshProUGUI passwordUIText;
    [SerializeField] private TextMeshProUGUI passwordWorldText;

    public static HiddenSecretsManager instance;

    private int secretsFound = 0;
    private char[] password = new char[11];

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

    public void AddSecretFound()
    {
        secretsFound += 1;

        secretsFoundText.text = "Znalezione zabytki: " + secretsFound.ToString() + " / 4";
    }

    public void AddPasswordElement(char character, int index)
    {
        password[index] = character;

        FillPassword();
    }

    private void FillPassword()
    {
        passwordUIText.text = string.Join(" ", password);
        passwordWorldText.text = string.Join(" ", password);
    }
}
