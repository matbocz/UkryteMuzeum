using UnityEngine;

public class GameStateManager : MonoBehaviour
{
    [HideInInspector] public bool gameIsPaused = false;

    public static GameStateManager instance;

    private void Awake()
    {
        CreateInstance();
    }

    private void CreateInstance()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != null)
        {
            Destroy(gameObject);
        }
    }

    public void ResumeGame()
    {
        StartPlayer();
        HideCursor();

        gameIsPaused = false;
    }

    public void PauseGame()
    {
        StopPlayer();
        ShowCursor();

        gameIsPaused = true;
    }

    public void StartPlayer()
    {
        FindObjectOfType<PlayerLook>().enabled = true;
        FindObjectOfType<PlayerMove>().enabled = true;
    }

    public void StopPlayer()
    {
        FindObjectOfType<PlayerLook>().enabled = false;
        FindObjectOfType<PlayerMove>().enabled = false;
    }

    public void ShowCursor()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    public void HideCursor()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
}
