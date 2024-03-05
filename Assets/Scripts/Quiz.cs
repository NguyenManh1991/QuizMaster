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
        questionText.text = question.GetQuestion();
        for (int i = 0; i < answerBottons.Length; i++)
        {
            TextMeshProUGUI bottonText = answerBottons[i].GetComponentInChildren<TextMeshProUGUI>();
            bottonText.text = question.GetAnswer(i);
        }
    }
    public void OnAnswerSelected(int index)
    {
        if (index == question.GetCorrectAnswerIndex())
        {
            questionText.text = "Correct";
            Image buttonImage = answerBottons[index].GetComponentInChildren<Image>();
            buttonImage.sprite = correctAnswerSprite;
        }
        else
        {
            questionText.text = "Not correct";
            Image buttonImage= answerBottons[index].GetComponentInChildren<Image>();
            buttonImage.sprite = defaultAnswerSprite;
        }
    }
    
}
