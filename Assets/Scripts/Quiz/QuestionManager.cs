using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class QuestionManager : MonoBehaviour
{
    [Header("Buttons")]
    [SerializeField] private Button[] answerButtons = new Button[4];

    [Space(10)]
    [SerializeField] private Button correctButton;
    [SerializeField] private Button nextQuestionButton;

    [Header("Time for the next question (seconds)")]
    [SerializeField] private int time = 5;

    private bool questionAnswered = false;

    private void Start()
    {
        // Hide the Next Question Button
        nextQuestionButton.gameObject.SetActive(false);
    }

    private void Update()
    {
        // If the user answered the question, start counting down to the next question
        if (questionAnswered == true)
        {
            StartCoroutine(FindObjectOfType<QuizManager>().WaitBeforeShowNextQuestionCoroutine(time));
        }
    }

    public void AnswerQuestion()
    {
        // Get the button clicked by the user
        GameObject clickedButton = EventSystem.current.currentSelectedGameObject;

        // Check that the user clicked the correct button
        if (clickedButton.name == correctButton.name)
        {
            HandleGoodAnswer(clickedButton);
        }
        else
        {
            HandleBadAnswer(clickedButton);
        }

        // Set that the question has been answered
        questionAnswered = true;

        // Show the Next Question Button
        nextQuestionButton.gameObject.SetActive(true);

        // Disable all Question Buttons
        DisableAllAnswerButtons();
    }

    private void DisableAllAnswerButtons()
    {
        foreach (Button button in answerButtons)
        {
            button.enabled = false;
        }
    }

    private void HandleGoodAnswer(GameObject clickedButton)
    {
        // Change the color of the clicked button
        clickedButton.GetComponent<Button>().image.color = FindObjectOfType<QuizManager>().GetGoodButtonColor();

        // Play the good answer sound
        AudioStateManager.instance.PlaySound("GoodAnswer");

        // Give the user one point
        FindObjectOfType<QuizManager>().IncreasePoints();
    }

    private void HandleBadAnswer(GameObject clickedButton)
    {
        // Change the color of the clicked button and the color of the correct button
        clickedButton.GetComponent<Button>().image.color = FindObjectOfType<QuizManager>().GetBadButtonColor();
        correctButton.image.color = FindObjectOfType<QuizManager>().GetGoodButtonColor();

        // Play the bad answer sound
        AudioStateManager.instance.PlaySound("BadAnswer");
    }
}
