using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    Quiz quiz;
    EndSceen endSceen;
    private void Awake()
    {
        quiz = FindObjectOfType<Quiz>();
        endSceen = FindObjectOfType<EndSceen>();
    }
    void Start()
    {
        
        quiz.gameObject.SetActive(true);
        endSceen.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(quiz.isComplate)
        {
            quiz.gameObject.SetActive(false);
            endSceen.gameObject.SetActive(true) ;
            endSceen.ShowFinalScore();
        }
        
    }
  public  void OnRePlayLever()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
