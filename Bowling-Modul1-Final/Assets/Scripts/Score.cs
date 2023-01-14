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
    public int finalScore;
    public int[] turnsScore;

    private bool isNextTurn = true;

    [Header("UI Elements")]
    public TextMeshProUGUI[] turnScoreText;
   
    private SpawnManager spawnManager;
    private GameManager gameManager;

 
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

        spawnManager = FindObjectOfType<SpawnManager>();
        gameManager = FindObjectOfType<GameManager>();
        
        PlayerPrefs.SetInt("StartScore", startScore);
    }

    private void Update()
    {
        TurnsSystem();
        CalculateFinalScore();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("ScoreTrigger"))
        {
            Debug.Log("Pin Fell");
            _currentScore++;
            PlayerPrefs.SetInt("CurrentScore", _currentScore);          
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
        Turn10();
    }

    public void Turn1()
    {
        if (gameManager.turns == 2)
        {
            ResetScore();
            turnScoreText[0].text = "Turn1 Score: " + PlayerPrefs.GetInt("CurrentScore", _currentScore);
            turnsScore[0] = PlayerPrefs.GetInt("CurrentScore", _currentScore);
            isNextTurn = true;            
            gameManager.turns = gameManager.turns + 1; 
        }
    }

    public void Turn2()
    {
        if (gameManager.turns == 4)
        {
            ResetScore();         
            turnScoreText[1].text = "Turn2 Score: " + PlayerPrefs.GetInt("CurrentScore", _currentScore);
            turnsScore[1] = PlayerPrefs.GetInt("CurrentScore", _currentScore);
            isNextTurn = true;
            gameManager.turns = gameManager.turns + 1;
        }        
    }

    public void Turn3()
    {
        if (gameManager.turns == 6)
        { 
            ResetScore();
            turnScoreText[2].text = "Turn3 Score: " + PlayerPrefs.GetInt("CurrentScore", _currentScore);
            turnsScore[2] = PlayerPrefs.GetInt("CurrentScore", _currentScore);
            isNextTurn = true;
            gameManager.turns = gameManager.turns + 1;
        }
    }

    public void Turn4()
    {
        if (gameManager.turns == 8)
        {
            ResetScore();
            turnScoreText[3].text = "Turn4 Score: " + PlayerPrefs.GetInt("CurrentScore", _currentScore);
            turnsScore[3] = PlayerPrefs.GetInt("CurrentScore", _currentScore);
            isNextTurn = true;
            gameManager.turns = gameManager.turns + 1;
        }
    }

    public void Turn5()
    {
        if (gameManager.turns == 10)
        {
            ResetScore();
            turnScoreText[4].text = "Turn5 Score: " + PlayerPrefs.GetInt("CurrentScore", _currentScore);
            turnsScore[4] = PlayerPrefs.GetInt("CurrentScore", _currentScore);
            isNextTurn = true;
            gameManager.turns = gameManager.turns + 1;
        }
    }

    public void Turn6()
    {
        if (gameManager.turns == 12)
        {
            ResetScore();
            turnScoreText[5].text = "Turn6 Score: " + PlayerPrefs.GetInt("CurrentScore", _currentScore);
            turnsScore[5] = PlayerPrefs.GetInt("CurrentScore", _currentScore);
            isNextTurn = true;
            gameManager.turns = gameManager.turns + 1;
        }
    }

    public void Turn7()
    {
        if (gameManager.turns == 14)
        {
            ResetScore();
            turnScoreText[6].text = "Turn7 Score: " + PlayerPrefs.GetInt("CurrentScore", _currentScore);
            turnsScore[6] = PlayerPrefs.GetInt("CurrentScore", _currentScore);
            isNextTurn = true;
            gameManager.turns = gameManager.turns + 1;
        }
    }

    public void Turn8()
    {
        if (gameManager.turns == 16)
        {
            ResetScore();
            turnScoreText[7].text = "Turn8 Score: " + PlayerPrefs.GetInt("CurrentScore", _currentScore);
            turnsScore[7] = PlayerPrefs.GetInt("CurrentScore", _currentScore);
            isNextTurn = true;
            gameManager.turns = gameManager.turns + 1;
        }
    }

    public void Turn9()
    {
        if (gameManager.turns == 18)
        {
            ResetScore();
            turnScoreText[8].text = "Turn9 Score: " + PlayerPrefs.GetInt("CurrentScore", _currentScore);
            turnsScore[8] = PlayerPrefs.GetInt("CurrentScore", _currentScore);
            isNextTurn = true;
            gameManager.turns = gameManager.turns + 1;
        }
    }

    public void Turn10()
    {
        if (gameManager.turns == 20)
        {
            ResetScore();
            turnScoreText[9].text = "Turn10 Score: " + PlayerPrefs.GetInt("CurrentScore", _currentScore);
            turnsScore[9] = PlayerPrefs.GetInt("CurrentScore", _currentScore);
            //isNextTurn = true;
            //gameManager.turns = gameManager.turns + 1;
        }
    }

    public void ResetScore()
    {
        if (isNextTurn)
        {
            _currentScore = startScore;
            isNextTurn = false;
        }
    }
    
    public void CalculateFinalScore()
    {
        finalScore = turnsScore[0] +turnsScore[1] + turnsScore[2] + turnsScore[3] + turnsScore[4] + turnsScore[5] + turnsScore[6] + turnsScore[7] + turnsScore[8] + turnsScore[9];

        PlayerPrefs.SetInt("FinalScore", finalScore);
    }
 }
