using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;


public class Quiz : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI questionText;
    [SerializeField] QuestionSo question;
    [SerializeField] GameObject[] answerBottons;
    int correctAnswerIndex;
    [SerializeField] Sprite defaultAnswerSprite;
    [SerializeField] Sprite correctAnswerSprite;
    void Start()
    {
        // DisplayQuestion();
        GetNextQuestion();
    }

    
    public void OnAnswerSelected(int index)
    {
        Image buttonImage;
        if (index == question.GetCorrectAnswerIndex())
        {
            questionText.text = "Correct";
            buttonImage = answerBottons[index].GetComponentInChildren<Image>();
            buttonImage.sprite = correctAnswerSprite;
        }
        else
        {
            correctAnswerIndex=question.GetCorrectAnswerIndex();
            string correctAnswer =question.GetAnswer(correctAnswerIndex);
            questionText.text ="Sorry correct answer was: \n "+ correctAnswer;
            buttonImage = answerBottons[correctAnswerIndex].GetComponent<Image>();
            buttonImage.sprite = correctAnswerSprite;

        }
        SetButtonState(false);
    }
    void GetNextQuestion()
    {
        SetButtonState(true);
        SetDefaultButtonSprites();
        DisplayQuestion();
    }

    void DisplayQuestion()
    {
        questionText.text = question.GetQuestion();
        for (int i = 0; i < answerBottons.Length; i++)
        {
            TextMeshProUGUI bottonText = answerBottons[i].GetComponentInChildren<TextMeshProUGUI>();
            bottonText.text = question.GetAnswer(i);
        }
    }
    void SetButtonState(bool state)
    {
        for(int i=0; i<answerBottons.Length; i++)
        {
            Button button= answerBottons[i].GetComponent<Button>();
            button.interactable = state;
        }
    }
    void SetDefaultButtonSprites()
    {
        for(int i=0; i < answerBottons.Length; i++)
        {
            Image buttonImage = answerBottons[i].GetComponent<Image>();
            buttonImage.sprite = defaultAnswerSprite;
        }
    }
}
