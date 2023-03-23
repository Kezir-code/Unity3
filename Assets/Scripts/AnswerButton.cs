using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class AnswerButton : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI answerText;
    [SerializeField] private Image outline;
    [SerializeField] private Button button;

    private bool correctAnswer = false;

    private void Awake()
    {
        button.onClick.AddListener(CheckAnswer);
    }

    public void SetAnswer(string answer, bool correctAnswer)
    {
        outline.color = Color.white;
        answerText.text = answer;
        this.correctAnswer = correctAnswer;
    }

    private void CheckAnswer()
    {
        if (correctAnswer)
        {
            outline.color = Color.green;
        }
        else
        {
            outline.color = Color.red;
        }
    }
}
