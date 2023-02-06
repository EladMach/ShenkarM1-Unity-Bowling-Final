using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;


public class GameManager : MonoBehaviour
{
    [Header("Variables")]
    public int[] frames;
    public int frameCounter;
    public float volume = 0.2f;
    public bool isStrike = false;
    public bool isSpare = false;
    public bool isOptions = false;
    public int pinsCount;

    private bool isTimerOn = true;
    private float fillSpeed = 1.0f;

    [Header("UI Elements")]
    public Slider timeBar;
    public TextMeshProUGUI timeText;
    public TextMeshProUGUI framesText;
    public TextMeshProUGUI throwsText;
    public TextMeshProUGUI totalScoreText;
    public TextMeshProUGUI player1NameText;
    public TextMeshProUGUI player2NameText;

    [Header("GameObjects")]
    public GameObject[] pins;
    public GameObject optionsPanel;

    private Score scoreScript;
    private Ball ball;    
    private Pin pinScript;
    private Vector3[] positions;
    private AudioSource audioSource;
    
    

    private void Start()
    {
        pinsCount = 0;
        pinScript = FindObjectOfType<Pin>();
        pins = GameObject.FindGameObjectsWithTag("Pin");
        ball = FindObjectOfType<Ball>();
        scoreScript = GameObject.Find("ScoreManager").GetComponent<Score>();
        positions = new Vector3[pins.Length];
        audioSource = GetComponent<AudioSource>();
        audioSource.Play();
        player1NameText.text = "Player 1: " + PlayerPrefs.GetString("Player1Name");
        player2NameText.text = "Player 2: " + PlayerPrefs.GetString("Player2Name");
    }

    private void Update()
    {
        
        framesText.text = "Frame: " + frameCounter.ToString();
        throwsText.text = "Throws: " + ball._throwsCount.ToString();
        totalScoreText.text = "Total Score: " + scoreScript.totalScore.ToString();
        timeText.text = "Timer: " + timeBar.value.ToString("F0");
        CountPins();
        TimerDown();
        ResetTimer();
    }

    public void TimerDown()
    {
        if (isTimerOn == true)
        {
            timeBar.value -= fillSpeed * Time.deltaTime;
        }
        if (ball._isThrown == true)
        {
            isTimerOn = false;   
        }
        else if (ball._isThrown == false)
        {
            isTimerOn = true;
        }   
    }

    private void ResetTimer()
    {
        if (ball._isMoving == true)
        {
            timeBar.value = 10;
        }
    }

    public void CountPins()
    {
        foreach (GameObject pin in pins)
        {
            if (pin.transform.eulerAngles.z > 20 && pin.transform.eulerAngles.z < 355 && pin.activeSelf)
            {
                scoreScript._currentScore++;
                pinsCount++;
                pin.SetActive(false);   
            }
        }  
    }

    public void ResetPins()
    {
        foreach (GameObject pin in pins)
        {   
            pin.GetComponent<Pin>().ResetPin();
            pin.SetActive(true);
        }

        FrameCounterSystem();
    }


    public void FrameCounterSystem()
    {
        if (scoreScript.isNextFrame == true)
        {
            frameCounter++;
            frames[frameCounter] = frameCounter;
        }        
    }

    public void RestartGame()
    {
        Debug.Log("GameEnded");
        SceneManager.LoadScene(0);
    }

    public void PauseGame()
    {
        Time.timeScale = 0f;
        AudioListener.pause = true;
        isOptions = true;
        optionsPanel.SetActive(true);
    }
    public void ResumeGame()
    {
        isOptions = false;
        Time.timeScale = 1;
        AudioListener.pause = false;
        optionsPanel.SetActive(false);
        scoreScript.player1winText.gameObject.SetActive(false);
        scoreScript.player2winText.gameObject.SetActive(false);
    }

    public void BackToMainMenu()
    {
        Time.timeScale = 1f;
        AudioListener.pause = false;
        isOptions = false;
        SceneManager.LoadScene(0);
    }

    public void GameOver()
    {
        SceneManager.LoadScene(0);
    }
}
