using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class QuestionManager : MonoBehaviour
{
    [Header("Buttons")]
    [SerializeField] private Button[] questionButtons = new Button[4];

    [Space(10)]
    [SerializeField] private Button correctButton;
    [SerializeField] private Button nextQuestionButton;

    [Header("Button colors")]
    [SerializeField] private Color goodButtonColor = Color.green;
    [SerializeField] private Color badButtonColor = Color.red;

    private void Start()
    {
        // Hide the Next Question Button
        nextQuestionButton.gameObject.SetActive(false);
    }

    public void AnswerQuestion()
    {
        // Get button clicked by user
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

        // Show the Next Question Button
        nextQuestionButton.gameObject.SetActive(true);

        // Disable all Question Buttons
        DisableAllQuestionButtons();
    }

    private void DisableAllQuestionButtons()
    {
        foreach (Button button in questionButtons)
        {
            button.enabled = false;
        }
    }

    private void HandleGoodAnswer(GameObject clickedButton)
    {
        // Change the color of the clicked button
        clickedButton.GetComponent<Button>().image.color = goodButtonColor;

        // Play the good answer sound
        FindObjectOfType<AudioStateManager>().PlaySound("GoodAnswer");

        // Give the user one point
        FindObjectOfType<QuizManager>().IncreasePoints();
    }

    private void HandleBadAnswer(GameObject clickedButton)
    {
        // Change the color of the clicked button and the color of the correct button
        clickedButton.GetComponent<Button>().image.color = badButtonColor;
        correctButton.image.color = goodButtonColor;

        // Play the bad answer sound
        FindObjectOfType<AudioStateManager>().PlaySound("BadAnswer");
    }
}
