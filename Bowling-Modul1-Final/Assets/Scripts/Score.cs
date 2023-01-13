using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class Score : MonoBehaviour
{
    [Header("Variables")]
    public int _currentScore;
    public int _score;
    
    

    [Header("UI Elements")]
    public TextMeshProUGUI scoreText;

    private GameManager gameManager;

    private void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
        scoreText.text = "Score " + _score;
        PlayerPrefs.SetInt("Start Score", _score);
    }

    private void Update()
    {

        scoreText.text = "Score: " + _currentScore.ToString();
        ResetScore();
        
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("ScoreTrigger"))
        {
            Debug.Log("Pin Fell");
            _currentScore++;
        }
     
    }


    public void ResetScore()
    {
        if (gameManager.turns == 2 || gameManager.turns == 5 || gameManager.turns == 8) 
        {
            _currentScore = PlayerPrefs.GetInt("Start Score", _score);
        }

    }

    

   

}
