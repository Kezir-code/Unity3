using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public enum QuizType
{
    Button = 0,
    Timer = 1
}
public class GameManager : Singleton<GameManager>
{
    [SerializeField] private TextMeshProUGUI questionText, questionNumberText, correctAnswersText;
    [SerializeField] private QuestionSO[] question;
    [SerializeField] private AnswerButton[] answerButtons = new AnswerButton[4];
    private int currentQuestion, correctAnswers;
    [SerializeField] private QuizType quizType;
    [SerializeField] private Button nextQuestion;
    private bool questionAnswered;
    [SerializeField] private Timer timer;

    void Start()
    {
        currentQuestion = 0;
        if (quizType == QuizType.Button)
        {
            timer.Activate(false);
            nextQuestion.onClick.AddListener(GoToNextQuestion);
        }
        else if(quizType == QuizType.Timer)
        {
            timer.Activate(true);
            nextQuestion.gameObject.SetActive(false);
        }
        RefreshQuestionNumber();
        SetUpNewQuestion();
    }

    private void RefreshQuestionNumber()
    {
        questionNumberText.text = (currentQuestion+1) + "/" + question.Length;
    }
    
    private void RefreshCorrectAnswersPercentage()
    {
        correctAnswersText.text = Mathf.Round(((float)correctAnswers/(currentQuestion+1)) * 100).ToString() + "%";
    }

    private void SetUpNewQuestion()
    {
        questionAnswered = false;
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
        questionAnswered = true;
        SetUpButtonsState(false);
        if (quizType == QuizType.Timer)
        {
            timer.CancelTimer();
        }
    }

    public void GoToNextQuestion()
    {
        currentQuestion++;
        if (questionAnswered)
        {
            SetUpNewQuestion();
        }
        else
        {
            UpdateScore(false);
            SetUpNewQuestion();
        }
        RefreshQuestionNumber();
    }
    
    public void ShowCorrectAnswer()
    {
        answerButtons[question[currentQuestion].GetCorrectAnswerIndex()].ShowCorrectAnswer();
    }

    public void SetUpButtonsState(bool value)
    {
        foreach (var answer in answerButtons)
        {
            answer.SetUpButtonState(value);
        }
    }

    public void UpdateScore(bool correctAnswer)
    {
        if (correctAnswer == true)
        {
            correctAnswers++;
        }
        RefreshCorrectAnswersPercentage();

    }
}
