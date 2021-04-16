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

    //private void OnTriggerEnter(Collider collider)
    //{
    //    if (collider.gameObject.tag == "Player" && gameObject.tag != "MuseumSecret")
    //    {
    //        OpenSecretPanel();

    //        if (gameObject.tag == "HiddenSecret" && isFound == false)
    //        {
    //            FindSecret();
    //        }
    //    }
    //}

    public void OpenSecretPanel()
    {
        secretPanel.SetActive(true);

        StopTime();
        ShowCursor();
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

    private void StopTime()
    {
        Camera.main.GetComponent<PlayerLook>().enabled = false;

        Time.timeScale = 0;
    }

    private void ShowCursor()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    public void CloseSecretPanel()
    {
        secretPanel.SetActive(false);

        StartTime();
        HideCursor();
    }

    private void StartTime()
    {
        Camera.main.GetComponent<PlayerLook>().enabled = true;

        Time.timeScale = 1;
    }

    private void HideCursor()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
}
