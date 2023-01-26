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
    public bool isGameOver = false;
    public bool isNextFrame = false;


    [Header("UI Elements")]
    public TextMeshProUGUI[] frameScoreText;

    private GameManager gameManager;
    private Ball ball;
    


    private void Start()
    {   
        startScore = 0; totalScore = 0;
        frameScoreText[0].text = "Frame 1: ";
        frameScoreText[1].text = "Frame 2: ";
        frameScoreText[2].text = "Frame 3: ";
        frameScoreText[3].text = "Frame 4: ";
        frameScoreText[4].text = "Frame 5: ";
        frameScoreText[5].text = "Frame 6: ";
        frameScoreText[6].text = "Frame 7: ";
        frameScoreText[7].text = "Frame 8: ";
        frameScoreText[8].text = "Frame 9: ";
        frameScoreText[9].text = "Frame 10: ";

        gameManager = FindObjectOfType<GameManager>();
        ball = FindObjectOfType<Ball>();    
        PlayerPrefs.SetInt("StartScore", startScore);
        PlayerPrefs.Save();
    }

    private void Update()
    {
        TurnsSystem();
        CalculateFinalScore();
        HighScore();
        PlayerPrefs.SetInt("CurrentScore", _currentScore);
    }

 
    public void TurnsSystem()
    {
        Frame1();
        Frame2();
        Frame3();
        Frame4();
        Frame5();
        Frame6();
        Frame7();
        Frame8();
        Frame9();
        Frame10();
    }


    public void Frame1()
    {
        if (ball._throwsCount == 1 && isNextFrame)
        {
            frameScoreText[0].text = "Frame 1: " + PlayerPrefs.GetInt("CurrentScore", _currentScore);
            frameScore[0] = PlayerPrefs.GetInt("CurrentScore", _currentScore); 
        }
        if (ball._throwsCount == 2 && isNextFrame)
        { 
            ResetScore();
            gameManager.ResetPins();  
            gameManager.frameCounter++;
        }

    }

    public void Frame2()
    {
        if (ball._throwsCount == 3 && isNextFrame)
        {
            frameScoreText[1].text = "Frame 2: " + PlayerPrefs.GetInt("CurrentScore", _currentScore);
            frameScore[1] = PlayerPrefs.GetInt("CurrentScore", _currentScore);
        }
        if (ball._throwsCount == 4 && isNextFrame)
        { 
            ResetScore();
            gameManager.ResetPins();
            gameManager.frameCounter++;
        }
    }

    public void Frame3()
    {
        if (ball._throwsCount == 5 && isNextFrame)
        {
            frameScoreText[2].text = "Frame 3: " + PlayerPrefs.GetInt("CurrentScore", _currentScore);
            frameScore[2] = PlayerPrefs.GetInt("CurrentScore", _currentScore);   
        }
        if (ball._throwsCount == 6 && isNextFrame)
        {
            ResetScore();
            gameManager.ResetPins();
            gameManager.frameCounter++;
        }
        
    }

    public void Frame4()
    {
        if (ball._throwsCount == 7 && isNextFrame)
        {
            frameScoreText[3].text = "Frame 4: " + PlayerPrefs.GetInt("CurrentScore", _currentScore);
            frameScore[3] = PlayerPrefs.GetInt("CurrentScore", _currentScore);           
        }
        if (ball._throwsCount == 8 && isNextFrame)
        {
            ResetScore();
            gameManager.ResetPins();
            gameManager.frameCounter++;
        }
        
    }

    public void Frame5()
    {
        if (ball._throwsCount == 9 && isNextFrame)
        {
            frameScoreText[4].text = "Frame 5: " + PlayerPrefs.GetInt("CurrentScore", _currentScore);
            frameScore[4] = PlayerPrefs.GetInt("CurrentScore", _currentScore);
        }
        if (ball._throwsCount == 10 && isNextFrame)
        {
            ResetScore();
            gameManager.ResetPins();
            gameManager.frameCounter++;
        }
    }

    public void Frame6()
    {
        if (ball._throwsCount == 11 && isNextFrame)
        {
            frameScoreText[5].text = "Frame 6: " + PlayerPrefs.GetInt("CurrentScore", _currentScore);
            frameScore[5] = PlayerPrefs.GetInt("CurrentScore", _currentScore);    
        }
        if (ball._throwsCount == 12 && isNextFrame)
        {
            ResetScore();
            gameManager.ResetPins();
            gameManager.frameCounter++;
        }
    }

    public void Frame7()
    {
        if (ball._throwsCount == 13 && isNextFrame)
        {
            frameScoreText[6].text = "Frame 7: " + PlayerPrefs.GetInt("CurrentScore", _currentScore);
            frameScore[6] = PlayerPrefs.GetInt("CurrentScore", _currentScore);
        }
        if (ball._throwsCount == 14 && isNextFrame)
        {
            ResetScore();
            gameManager.ResetPins();
            gameManager.frameCounter++;
        }
    }

    public void Frame8()
    {
        if (ball._throwsCount == 15 && isNextFrame)
        {
            frameScoreText[7].text = "Frame 8: " + PlayerPrefs.GetInt("CurrentScore", _currentScore);
            frameScore[7] = PlayerPrefs.GetInt("CurrentScore", _currentScore);
        }
        if (ball._throwsCount == 16 && isNextFrame)
        {
            ResetScore();
            gameManager.ResetPins();
            gameManager.frameCounter++;
        }
    }

    public void Frame9()
    {
        if (ball._throwsCount == 17 && isNextFrame)
        {
            frameScoreText[8].text = "Frame 9: " + PlayerPrefs.GetInt("CurrentScore", _currentScore);
            frameScore[8] = PlayerPrefs.GetInt("CurrentScore", _currentScore);
        }
        if (ball._throwsCount == 18 && isNextFrame)
        {
            ResetScore();
            gameManager.ResetPins();
            gameManager.frameCounter++;
        }
    }

    public void Frame10()
    {
        if (ball._throwsCount == 19 && isNextFrame)
        {
            frameScoreText[9].text = "Frame 10: " + PlayerPrefs.GetInt("CurrentScore", _currentScore);
            frameScore[9] = PlayerPrefs.GetInt("CurrentScore", _currentScore);
        }
        if (ball._throwsCount == 20 && isNextFrame)
        {
            ResetScore();
            gameManager.ResetPins();
            isGameOver = true;
        }
    }

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
        totalScore = frameScore[0] + frameScore[1] + frameScore[2] + frameScore[3] + frameScore[4] + frameScore[5] + frameScore[6] + frameScore[7] + frameScore[8] + frameScore[9];

        PlayerPrefs.SetInt("FinalScore", totalScore);
    }

    public void HighScore()
    {
        if (PlayerPrefs.GetInt("HighScore") < totalScore)
        {
            PlayerPrefs.SetInt("HighScore", totalScore);
        }
    }

 }
