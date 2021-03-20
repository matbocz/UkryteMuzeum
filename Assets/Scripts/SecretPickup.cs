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
        if (other.gameObject.tag == "Player")
        {
            Debug.Log("Secret!");
            //Destroy(gameObject);

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
        Camera.main.GetComponent<PlayerLooking>().enabled = false;
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
        Camera.main.GetComponent<PlayerLooking>().enabled = true;
        Time.timeScale = 1;
    }

    private void HideCursor()
    {
        Camera.main.GetComponent<PlayerLooking>().enabled = true;

        Time.timeScale = 1;

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
}
