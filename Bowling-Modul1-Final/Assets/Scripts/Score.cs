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
    public int _currentScore;
    public int totalScore;
    public int[] frameScore;

    private bool isNextFrame = false;
    public bool isStrike = false;
    

    [Header("UI Elements")]
    public TextMeshProUGUI[] frameScoreText;

    private GameManager gameManager;
    private Ball ball;
    


    private void Start()
    {   
        startScore = 0; totalScore = 0;
        frameScoreText[0].text = "Frame1 Score: ";
        frameScoreText[1].text = "Frame2 Score: ";
        frameScoreText[2].text = "Frame3 Score: ";
        frameScoreText[3].text = "Frame4 Score: ";
        frameScoreText[4].text = "Frame5 Score: ";
        frameScoreText[5].text = "Frame6 Score: ";
        frameScoreText[6].text = "Frame7 Score: ";
        frameScoreText[7].text = "Frame8 Score: ";
        frameScoreText[8].text = "Frame9 Score: ";
        frameScoreText[9].text = "Frame10 Score: ";

        gameManager = FindObjectOfType<GameManager>();
        ball = FindObjectOfType<Ball>();    
        PlayerPrefs.SetInt("StartScore", startScore);
    }

    private void Update()
    {
        TurnsSystem();
        CalculateFinalScore();
        //Strike();
        PlayerPrefs.SetInt("CurrentScore", _currentScore);
    }

 
    public void TurnsSystem()
    {
        Turn1();
        Turn2();
        Turn3();
        //Turn4();
        //Turn5();
        //Turn6();
        //Turn7();
        //Turn8();
        //Turn9();
        
    }

    public void Strike()
    {
        Debug.Log("Strike!");
        isStrike = true;  
        
    }

    public void Turn1()
    {
        for (int i = 0; i < gameManager.frames.Length; i++)
        {
            if (gameManager.frames[i] == 1)
            {          
                isNextFrame = true;
                frameScoreText[0].text = "Turn1 Score: " + PlayerPrefs.GetInt("CurrentScore", _currentScore);
                frameScore[0] = PlayerPrefs.GetInt("CurrentScore", _currentScore);
                ResetScore();
            }
            
        }
        
    }

    public void Turn2()
    {
        for (int i = 0; i < gameManager.frames.Length; i++)
        {
            if (gameManager.frames[i] == 2)
            {   
                isNextFrame = true;
                frameScoreText[1].text = "Turn2 Score: " + PlayerPrefs.GetInt("CurrentScore", _currentScore);
                frameScore[1] = PlayerPrefs.GetInt("CurrentScore", _currentScore);
                ResetScore();
            }
            
        }
        
    }

    public void Turn3()
    {
        for (int i = 0; i < gameManager.frames.Length; i++)
        {
            if (gameManager.frames[i] == 3)
            {
                isNextFrame = true;
                frameScoreText[2].text = "Turn3 Score: " + _currentScore;
                frameScore[2] = PlayerPrefs.GetInt("CurrentScore", _currentScore);
                ResetScore();
            }
            
        }
    }

    //public void Turn4()
    //{
    //    if (gameManager.frames == 4)
    //    {
    //        ResetScore();
    //        frameScoreText[3].text = "Turn4 Score: " + PlayerPrefs.GetInt("CurrentScore", _currentScore);
    //        frameScore[3] = PlayerPrefs.GetInt("CurrentScore", _currentScore);
    //    }
    //}

    //public void Turn5()
    //{
    //    if (gameManager.frames == 5)
    //    {
    //        ResetScore();
    //        frameScoreText[4].text = "Turn5 Score: " + PlayerPrefs.GetInt("CurrentScore", _currentScore);
    //        frameScore[4] = PlayerPrefs.GetInt("CurrentScore", _currentScore);
    //    }
    //}

    //public void Turn6()
    //{
    //    if (gameManager.frames == 7)
    //    {
    //        ResetScore();
    //        frameScoreText[5].text = "Turn6 Score: " + PlayerPrefs.GetInt("CurrentScore", _currentScore);
    //        frameScore[5] = PlayerPrefs.GetInt("CurrentScore", _currentScore);
    //    }
    //}

    //public void Turn7()
    //{
    //    if (gameManager.frames == 8)
    //    {
    //        ResetScore();
    //        frameScoreText[6].text = "Turn7 Score: " + PlayerPrefs.GetInt("CurrentScore", _currentScore);
    //        frameScore[6] = PlayerPrefs.GetInt("CurrentScore", _currentScore);
    //    }
    //}

    //public void Turn8()
    //{
    //    if (gameManager.frames == 9)
    //    {
    //        ResetScore();
    //        frameScoreText[7].text = "Turn8 Score: " + PlayerPrefs.GetInt("CurrentScore", _currentScore);
    //        frameScore[7] = PlayerPrefs.GetInt("CurrentScore", _currentScore);
    //    }
    //}

    //public void Turn9()
    //{
    //    if (gameManager.frames == 10)
    //    {
    //        ResetScore();
    //        frameScoreText[8].text = "Turn9 Score: " + PlayerPrefs.GetInt("CurrentScore", _currentScore);
    //        frameScore[8] = PlayerPrefs.GetInt("CurrentScore", _currentScore);   
    //    }
    //}


    public void ResetScore()
    {
        if (isNextFrame == true)
        {
            _currentScore = startScore;
            isNextFrame = false;
        }
        
    }
    
    public void CalculateFinalScore()
    {
        totalScore = frameScore[0] +frameScore[1] + frameScore[2] + frameScore[3] + frameScore[4] + frameScore[5] + frameScore[6] + frameScore[7] + frameScore[8] + frameScore[9];

        PlayerPrefs.SetInt("FinalScore", totalScore);
    }
 }
