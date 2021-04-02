using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecretPickup : MonoBehaviour
{
    [SerializeField] GameObject secretPanel;

    private void Start()
    {
        secretPanel.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player" && gameObject.tag != "MuseumSecret")
        {
            Debug.Log("Secret!");

            OpenSecretPanel();
        }
    }

    public void OpenSecretPanel()
    {
        secretPanel.SetActive(true);

        StopTime();
        ShowCursor();
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
