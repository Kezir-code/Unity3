using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    [SerializeField] private TextMeshProUGUI questionText;
    [SerializeField] private QuestionSO[] question;
    [SerializeField] private AnswerButton[] answerButtons = new AnswerButton[4];
    private int currentQuestion;

    void Start()
    {
        currentQuestion = 0;
        SetUpNewQuestion();
    }

    private void SetUpNewQuestion()
    {
        questionText.text = question[currentQuestion].GetQuestion();

        int correctIndex = question[currentQuestion].GetCorrectAnswerIndex();
        for (int i = 0; i < answerButtons.Length; i++)
        {
            answerButtons[i].SetAnswer(question[currentQuestion].GetAnswer(i), i == correctIndex);
            answerButtons[i].SetUpButtonState(true);
        }
    }

    public void PrepareNewQuestion()
    {
        currentQuestion++;
        SetUpButtonsState(false);
        SetUpNewQuestion();
    }
    
    public void ShowCorrectAnswer()
    {
        answerButtons[question[currentQuestion].GetCorrectAnswerIndex()].ShowCorrectAnswer();
    }

    private void SetUpButtonsState(bool value)
    {
        foreach (var answer in answerButtons)
        {
            answer.SetUpButtonState(value);
        }
    }
}
