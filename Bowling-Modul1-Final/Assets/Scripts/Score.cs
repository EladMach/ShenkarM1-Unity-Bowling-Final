using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class Score : MonoBehaviour
{
    [Header("Variables")]
    public int _startScore;
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
    public TextMeshProUGUI scoreText;

    private GameManager gameManager;

    private void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
        scoreText.text = "Score " + _startScore;
        
    }

    private void Update()
    {

        scoreText.text = "Score: " + _currentScore.ToString();
        
        
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("ScoreTrigger"))
        {
            Debug.Log("Pin Fell");
            _currentScore++;
        }
     
    }

}
