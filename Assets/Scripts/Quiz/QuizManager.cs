using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class QuizManager : MonoBehaviour
{
    [Header("Panels")]
    [SerializeField] private GameObject startPanel;
    [SerializeField] private GameObject endPanel;

    [Space(10)]
    [SerializeField] private GameObject[] questionPanels = new GameObject[5];

    [Header("Button colors")]
    [SerializeField] private Color goodButtonColor = Color.green;
    [SerializeField] private Color badButtonColor = Color.red;

    private int questionNumber = 1;
    private int points = 0;

    private void Start()
    {
        // Show cursor
        GameStateManager.instance.ShowCursor();

        // Show Start Panel
        startPanel.SetActive(true);
    }

    public void StartQuiz()
    {
        // Hide Start Panel
        startPanel.SetActive(false);

        // Show first Question Panel
        questionPanels[0].SetActive(true);
    }

    public IEnumerator WaitBeforeShowNextQuestionCoroutine(int seconds)
    {
        // Wait before showing next Question Panel
        yield return new WaitForSeconds(seconds);
        ShowNextQuestion();
    }

    public void ShowNextQuestion()
    {
        // Hide previous Question Panel and show next Question Panel
        questionPanels[questionNumber - 1].SetActive(false);
        questionPanels[questionNumber].SetActive(true);

        // Increase Question Number
        questionNumber++;
    }

    public void ShowResults()
    {
        // Hide last Question Panel and show End Panel
        questionPanels[questionNumber - 1].SetActive(false);
        endPanel.SetActive(true);

        // Update text with results
        endPanel.GetComponentInChildren<Text>().text = "Wyniki: " + points.ToString() + " / " + questionPanels.Length.ToString();
    }

    public void EndQuiz()
    {
        // Load Start Menu scene
        SceneManager.LoadScene(0);
    }

    public void IncreasePoints()
    {
        points++;
    }

    public Color GetGoodButtonColor()
    {
        return goodButtonColor;
    }

    public Color GetBadButtonColor()
    {
        return badButtonColor;
    }
}
