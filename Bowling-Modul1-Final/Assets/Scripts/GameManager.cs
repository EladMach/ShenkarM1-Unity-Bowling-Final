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
        turns = Mathf.Clamp(turns, 0, 20);
        
    }

    private void Update()
    {          
        StartCoroutine(TimerDown());
        turnsText.text = "Turn: " + turns;
        timeText.text = "Timer: " + timeBar.value.ToString("F0");
        RestartGame();
        
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
        else
        {
            isTimerOn = true;
        }

        if (timeBar.value == 0)
        {
            timeBar.value = 10;
        }
        
        yield return null;
    }

    public void NextTurn()
    {
        turns = ball._throws;
          
    }

    private void RestartGame()
    {
        if (turns == 20)
        {
            SceneManager.LoadScene(0);
        }
    }

}
