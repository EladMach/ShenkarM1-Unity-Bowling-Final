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

    public bool isNextFrame = false;
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
        PlayerPrefs.Save();
    }

    private void Update()
    {
        TurnsSystem();
        CalculateFinalScore();
        Strike();
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
    }

    public void Strike()
    {
        if (_currentScore == 10)
        {
            Debug.Log("Strike!");
            isStrike = true;
            gameManager.ResetPins();
            gameManager.frameCounter++;
        }

    }

    public void Frame1()
    {
        if (gameManager.frameCounter == 1 && isNextFrame)
        {
            frameScoreText[0].text = "Frame1 Score: " + PlayerPrefs.GetInt("CurrentScore", _currentScore);
            frameScore[0] = PlayerPrefs.GetInt("CurrentScore", _currentScore);
        }
        else if (gameManager.frameCounter == 2 && isNextFrame)
        {
            ResetScore();
        }
                     
    }

    public void Frame2()
    {
        if (gameManager.frameCounter == 3 && isNextFrame)
        {
            frameScoreText[1].text = "Frame2 Score: " + PlayerPrefs.GetInt("CurrentScore", _currentScore);
            frameScore[1] = PlayerPrefs.GetInt("CurrentScore", _currentScore);
        }
        if (gameManager.frameCounter == 4 && isNextFrame)
        { 
            ResetScore();
        }
    }

    public void Frame3()
    {
        if (gameManager.frameCounter == 5)
        {
            frameScore[2] = PlayerPrefs.GetInt("CurrentScore", _currentScore);
            isNextFrame = true;
        }
        if (gameManager.frameCounter == 6 && isNextFrame)
        {
            ResetScore();
        }
    }

    public void Frame4()
    {
        if (gameManager.frameCounter == 7)
        {
            frameScore[3] = PlayerPrefs.GetInt("CurrentScore", _currentScore);
            isNextFrame = true;
        }
        if (gameManager.frameCounter == 8)
        {
            ResetScore();
        }
    }

    public void Frame5()
    {
        if (gameManager.frameCounter == 9)
        {
            frameScore[3] = PlayerPrefs.GetInt("CurrentScore", _currentScore);
            isNextFrame = true;
        }
        if (gameManager.frameCounter == 10)
        {
            ResetScore();
        }
    }

    public void Frame6()
    {
        if (gameManager.frameCounter == 11)
        {
            frameScore[4] = PlayerPrefs.GetInt("CurrentScore", _currentScore);
            isNextFrame = true;
        }
        if (gameManager.frameCounter == 12)
        {
            ResetScore();
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
 }
