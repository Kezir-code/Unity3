using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    [SerializeField] private TextMeshProUGUI questionText;
    [SerializeField] private QuestionSO question;
    [SerializeField] private AnswerButton[] answerButtons = new AnswerButton[4];

    void Start()
    {
        questionText.text = question.GetQuestion();

        int correctIndex = question.GetCorrectAnswerIndex();
        for (int i = 0; i < answerButtons.Length; i++)
        {
            answerButtons[i].SetAnswer(question.GetAnswer(i), i == correctIndex);
        }
    }

    public void ShowCorrectAnswer()
    {
        answerButtons[question.GetCorrectAnswerIndex()].ShowCorrectAnswer();
    }
}
