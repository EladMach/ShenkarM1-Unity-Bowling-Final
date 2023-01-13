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

    public int[] turnsScore;
    

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

    
    private SpawnManager spawnManager;
    private GameManager gameManager;

    private void Start()
    {
        turn1scoreText.text = "Turn1 Score: " + startScore.ToString();
        turn2scoreText.text = "Turn2 Score: " + startScore.ToString();
        turn3scoreText.text = "Turn3 Score: " + startScore.ToString();
        turn4scoreText.text = "Turn4 Score: " + startScore.ToString();
        turn5scoreText.text = "Turn5 Score: " + startScore.ToString();
        turn6scoreText.text = "Turn6 Score: " + startScore.ToString();
        turn7scoreText.text = "Turn7 Score: " + startScore.ToString();
        turn8scoreText.text = "Turn8 Score: " + startScore.ToString();
        turn9scoreText.text = "Turn9 Score: " + startScore.ToString();
        turn10scoreText.text = "Turn10 Score: " + startScore.ToString();

        spawnManager = FindObjectOfType<SpawnManager>();
        gameManager = FindObjectOfType<GameManager>();

        PlayerPrefs.SetInt("StartScore", startScore);
    }

    private void Update()
    {
        TurnsSystem();
     
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
    }

    public void Turn1()
    {
        if (gameManager.turns == 2)
        {
            turn1scoreText.text = "Turn1 Score: " + PlayerPrefs.GetInt("CurrentScore", _currentScore);
            turnsScore[0] = PlayerPrefs.GetInt("CurrentScore", _currentScore);             
        }
        
    }

    public void Turn2()
    {
        if (gameManager.turns == 4)
        {
            turn2scoreText.text = "Turn2 Score: " + PlayerPrefs.GetInt("CurrentScore", _currentScore);
            turnsScore[1] = PlayerPrefs.GetInt("CurrentScore", _currentScore);   
        }        
    }

    public void Turn3()
    {
        if (gameManager.turns == 6)
        { 
            turn3scoreText.text = "Turn3 Score: " + PlayerPrefs.GetInt("CurrentScore", _currentScore);
            turnsScore[2] = PlayerPrefs.GetInt("CurrentScore", _currentScore);

        }
    }

   
}
