using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class Score : MonoBehaviour
{
    [Header("Variables")]
    private int startScore; 
    public int _currentScore;
    public int turn1Score;
    public int turn2Score;
    public int turn3Score;
    public int turn4Score;
    public int turn5Score;
    public int turn6Score;
    public int turn7Score;
    public int turn8Score;
    public int turn9Score;
    public int turn10Score;
    
    

    [Header("UI Elements")]
    public TextMeshProUGUI turn1scoreText;
    public TextMeshProUGUI turn2scoreText;
    public TextMeshProUGUI turn3scoreText;
    public TextMeshProUGUI turn4scoreText;
    public TextMeshProUGUI turn5scoreText;
    public TextMeshProUGUI turn6scoreText;
    public TextMeshProUGUI turn7scoreText;
    public TextMeshProUGUI turn8scoreText;
    public TextMeshProUGUI turn9scoreText;
    public TextMeshProUGUI turn10scoreText;




    private GameManager gameManager;

    private void Start()
    {
        
        gameManager = FindObjectOfType<GameManager>();
        
        
    }

    private void Update()
    {
        turn1scoreText.text = "Turn1 Score: " + _currentScore.ToString();
        turn2scoreText.text = "Turn2 Score: " + _currentScore.ToString();

        PlayerPrefs.SetInt("StartScore", startScore);
        PlayerPrefs.SetInt("CurrentScore", _currentScore);
        Turn1();
        Turn2();
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("ScoreTrigger"))
        {
            Debug.Log("Pin Fell");
            _currentScore++; 
        }     
        
    }


    public void Turn1()
    {
        if (gameManager.turns == 2)
        {
            turn1Score = PlayerPrefs.GetInt("CurrentScore", _currentScore); 
            gameManager.isEndTurn = true;
        }      
    }

    public void Turn2()
    {
        
        if (gameManager.turns == 4)
        {
            turn2Score = PlayerPrefs.GetInt("CurrentScore", _currentScore);
        }
        
    }



}
