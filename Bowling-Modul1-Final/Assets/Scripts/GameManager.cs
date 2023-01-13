using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [Header("Variables")]
    public int turns = 1;
    private bool isTimerOn = true;
    private float fillSpeed = 1.0f;
    
    

    [Header("UI Elements")]
    public Slider timeBar;
    public TextMeshProUGUI timeText;
    public TextMeshProUGUI turnsText;

    private Score scoreScript;
    private Ball ball;
    private SpawnManager spawnManager;


    private void Start()
    {
        ball = FindObjectOfType<Ball>();
        scoreScript = GameObject.Find("ScoreManager").GetComponent<Score>();
        spawnManager = FindObjectOfType<SpawnManager>();
    }

    private void Update()
    {          
        StartCoroutine(TimerDown());
        turnsText.text = "Turn: " + turns;
        timeText.text = "Timer: " + timeBar.value.ToString("F0");
        
        
    }
    public IEnumerator TimerDown()
    {
        if (isTimerOn == true)
        {
            timeBar.value -= fillSpeed * Time.deltaTime;
        }

        if (ball._isThrown == true)
        {
            isTimerOn = false;
        }

        if (timeBar.value == 0)
        {
            isTimerOn = false;
            
        }

        if (ball._isThrown == false)
        {
            isTimerOn = true;     
        }

        yield return new WaitForSeconds(timeBar.value);
    }

    public void NextTurn()
    {
        if (scoreScript._currentScore == 10)
        {
            turns = turns + 1;
        }
        turns = ball._throws;

    }

    

}
