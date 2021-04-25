﻿using System.Collections;
using System.Collections.Generic;
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
        nextQuestionButton.gameObject.SetActive(false);
    }

    public void AnswerQuestion()
    {
        GameObject clickedButton = EventSystem.current.currentSelectedGameObject;

        ColorBlock clickedButtonColors = clickedButton.GetComponent<Button>().colors;
        ColorBlock correctButtonColors = correctButton.colors;

        DisableAllQuestionButtons();

        if (clickedButton.name == correctButton.name)
        {
            HandleGoodAnswer(clickedButton, clickedButtonColors);
        }
        else
        {
            HandleBadAnswer(clickedButton, clickedButtonColors, correctButtonColors);
        }

        nextQuestionButton.gameObject.SetActive(true);
    }

    private void DisableAllQuestionButtons()
    {
        foreach (Button button in questionButtons)
        {
            button.enabled = false;
        }
    }

    private void HandleGoodAnswer(GameObject clickedButton, ColorBlock clickedButtonColors)
    {
        clickedButtonColors.normalColor = goodButtonColor;

        clickedButton.GetComponent<Button>().colors = clickedButtonColors;

        QuizManager.instance.IncreasePoints();
    }

    private void HandleBadAnswer(GameObject clickedButton, ColorBlock clickedButtonColors, ColorBlock correctButtonColors)
    {
        clickedButtonColors.normalColor = badButtonColor;
        correctButtonColors.normalColor = goodButtonColor;

        clickedButton.GetComponent<Button>().colors = clickedButtonColors;
        correctButton.colors = correctButtonColors;
    }
}
