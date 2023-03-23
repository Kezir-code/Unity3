using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour
{
    [SerializeField] private float timerToCompleteQuestion = 15f;
    [SerializeField] private float timerToShowCorrectAnswer = 10f;

    public bool isAnsweringQuestion = false;
    
    private float timerValue;
    
    void Update()
    {
        UpdateTimer();
    }

    void UpdateTimer()
    {
        timerValue -= Time.deltaTime;

        if (isAnsweringQuestion)
        {
            if (timerValue <= 0)
            {
                isAnsweringQuestion = false;
                timerValue = timerToShowCorrectAnswer;
            }
        }
        else
        {
            if (timerValue <= 0)
            {
                isAnsweringQuestion = true;
                timerValue = timerToCompleteQuestion;
            }
        }
        
        
        Debug.Log(timerValue);
    }
}
