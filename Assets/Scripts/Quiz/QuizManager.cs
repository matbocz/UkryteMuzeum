using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuizManager : MonoBehaviour
{
    [Header("Panels")]
    [SerializeField] private GameObject startPanel;
    [SerializeField] private GameObject endPanel;

    [Space(10)]
    [SerializeField] private GameObject[] questionPanels = new GameObject[5];

    private int questionNumber = 1;
    private int points = 0;

    public static QuizManager instance;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        GameStateManager.instance.ShowCursor();

        startPanel.SetActive(true);
    }

    public void StartQuiz()
    {
        startPanel.SetActive(false);
        questionPanels[0].SetActive(true);
    }

    public void ShowNextQuestion()
    {
        questionPanels[questionNumber - 1].SetActive(false);
        questionPanels[questionNumber].SetActive(true);

        questionNumber++;
    }

    public void ShowResults()
    {
        questionPanels[questionNumber - 1].SetActive(false);
        endPanel.SetActive(true);

        endPanel.GetComponentInChildren<Text>().text = "Wyniki: " + GetPoints() + " / " + GetNumberOfQuestions();
    }

    private int GetPoints()
    {
        return points;
    }

    private int GetNumberOfQuestions()
    {
        return questionPanels.Length;
    }

    public void EndQuiz()
    {
        Debug.Log("End game");
        Application.Quit();
    }

    public void IncreasePoints()
    {
        points++;
    }
}
