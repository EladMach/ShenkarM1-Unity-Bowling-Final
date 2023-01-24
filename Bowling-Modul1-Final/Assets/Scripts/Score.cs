using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using Unity.VisualScripting;

public class Score : MonoBehaviour
{
    [Header("Variables")]
    private int startScore;
    public int score;
    public int _currentScore;
    public int totalScore;
    public int[] turnScore;

    private bool isNextTurn = true;
    public bool isStrike = false;
    

    [Header("UI Elements")]
    public TextMeshProUGUI[] turnScoreText;

    private GameManager gameManager;
    private Ball ball;
    


    private void Start()
    {     
        turnScoreText[0].text = "Turn1 Score: " + startScore.ToString();
        turnScoreText[1].text = "Turn2 Score: " + startScore.ToString();
        turnScoreText[2].text = "Turn3 Score: " + startScore.ToString();
        turnScoreText[3].text = "Turn4 Score: " + startScore.ToString();
        turnScoreText[4].text = "Turn5 Score: " + startScore.ToString();
        turnScoreText[5].text = "Turn6 Score: " + startScore.ToString();
        turnScoreText[6].text = "Turn7 Score: " + startScore.ToString();
        turnScoreText[7].text = "Turn8 Score: " + startScore.ToString();
        turnScoreText[8].text = "Turn9 Score: " + startScore.ToString();
        turnScoreText[9].text = "Turn10 Score: " + startScore.ToString();

        gameManager = FindObjectOfType<GameManager>();
        ball = FindObjectOfType<Ball>();    
        PlayerPrefs.SetInt("StartScore", startScore);
    }

    private void Update()
    {
        TurnsSystem();
        CalculateFinalScore();
        Strike();
        PlayerPrefs.SetInt("CurrentScore", _currentScore);
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Ball"))
        {   
                
        }        
    }

 
    public void TurnsSystem()
    {
        Turn1();
        Turn2();
        Turn3();
        Turn4();
        Turn5();
        Turn6();
        Turn7();
        Turn8();
        Turn9();
        
    }

    public void Strike()
    {
        if (_currentScore == 10)
        {
            Debug.Log("Strike!");
            isStrike = true;  
        }
    }

    public void Turn1()
    {  
        if (gameManager.frames == 1)
        {
            ResetScore();
            turnScoreText[0].text = "Turn1 Score: " + PlayerPrefs.GetInt("CurrentScore", _currentScore);
            turnScore[0] = PlayerPrefs.GetInt("CurrentScore", _currentScore);
            isNextTurn = true;  
        }  
    }

    public void Turn2()
    {  
        if (gameManager.frames == 2)
        {
            ResetScore();         
            turnScoreText[1].text = "Turn2 Score: " + PlayerPrefs.GetInt("CurrentScore", _currentScore);
            turnScore[1] = PlayerPrefs.GetInt("CurrentScore", _currentScore);
            isNextTurn = true;
            
        }        
    }

    public void Turn3()
    {
        if (gameManager.frames == 3)
        { 
            ResetScore();
            turnScoreText[2].text = "Turn3 Score: " + PlayerPrefs.GetInt("CurrentScore", _currentScore);
            turnScore[2] = PlayerPrefs.GetInt("CurrentScore", _currentScore);
            isNextTurn = true;
        }
    }

    public void Turn4()
    {
        if (gameManager.frames == 4)
        {
            ResetScore();
            turnScoreText[3].text = "Turn4 Score: " + PlayerPrefs.GetInt("CurrentScore", _currentScore);
            turnScore[3] = PlayerPrefs.GetInt("CurrentScore", _currentScore);
            isNextTurn = true;
        }
    }

    public void Turn5()
    {
        if (gameManager.frames == 5)
        {
            ResetScore();
            turnScoreText[4].text = "Turn5 Score: " + PlayerPrefs.GetInt("CurrentScore", _currentScore);
            turnScore[4] = PlayerPrefs.GetInt("CurrentScore", _currentScore);
            isNextTurn = true;
        }
    }

    public void Turn6()
    {
        if (gameManager.frames == 7)
        {
            ResetScore();
            turnScoreText[5].text = "Turn6 Score: " + PlayerPrefs.GetInt("CurrentScore", _currentScore);
            turnScore[5] = PlayerPrefs.GetInt("CurrentScore", _currentScore);
            isNextTurn = true;
        }
    }

    public void Turn7()
    {
        if (gameManager.frames == 8)
        {
            ResetScore();
            turnScoreText[6].text = "Turn7 Score: " + PlayerPrefs.GetInt("CurrentScore", _currentScore);
            turnScore[6] = PlayerPrefs.GetInt("CurrentScore", _currentScore);
            isNextTurn = true;
        }
    }

    public void Turn8()
    {
        if (gameManager.frames == 9)
        {
            ResetScore();
            turnScoreText[7].text = "Turn8 Score: " + PlayerPrefs.GetInt("CurrentScore", _currentScore);
            turnScore[7] = PlayerPrefs.GetInt("CurrentScore", _currentScore);
            isNextTurn = true;
        }
    }

    public void Turn9()
    {
        if (gameManager.frames == 10)
        {
            ResetScore();
            turnScoreText[8].text = "Turn9 Score: " + PlayerPrefs.GetInt("CurrentScore", _currentScore);
            turnScore[8] = PlayerPrefs.GetInt("CurrentScore", _currentScore);
            isNextTurn = true;   
        }
    }



    private void ResetScore()
    {
        if (isNextTurn)
        {
            _currentScore = startScore;
            isNextTurn = false;
        }
    }
    
    public void CalculateFinalScore()
    {
        totalScore = turnScore[0] +turnScore[1] + turnScore[2] + turnScore[3] + turnScore[4] + turnScore[5] + turnScore[6] + turnScore[7] + turnScore[8] + turnScore[9];

        PlayerPrefs.SetInt("FinalScore", totalScore);
    }
 }
