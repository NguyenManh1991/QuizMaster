using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour
{
    [SerializeField] float timeToComplateQuestion = 30f;
    [SerializeField] float timeToShowCorrectAnswer = 10f;
    float timerValue;
    public bool isAnsweringQuestion=false;
    public float fillFraction;
    public bool loadNextQuestion;
    void Update()
    {
        TimerUpDate();
    }

    public void CancelTimer()
    {
        timerValue = 0; 
    }

    void TimerUpDate()
    {
        timerValue -= Time.deltaTime;
        if(isAnsweringQuestion)
        {
            if (timerValue > 0)
            {
                fillFraction = timerValue / timeToComplateQuestion;
            }
            else
            {
                isAnsweringQuestion = false;
                timerValue = timeToShowCorrectAnswer;
            }
        }
        else
        {
            if(timerValue > 0)
            {
                fillFraction = timerValue / timeToShowCorrectAnswer;
            }
            else 
            {
                isAnsweringQuestion = true;
                timerValue = timeToComplateQuestion;
                loadNextQuestion = true;
            }
        }
        Debug.Log(isAnsweringQuestion + ":" + timerValue + ":" + fillFraction );
    }
}
