using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEditor.AnimatedValues;

public class GameManager : MonoBehaviour
{
    [Header("Variables")]
    public int[] frames;
    public int frameCounter;
    private bool isTimerOn = true;
    private float fillSpeed = 1.0f;
    public bool isOptions = false;
    public float volume = 0.2f;
    

    [Header("UI Elements")]
    public Slider timeBar;
    public TextMeshProUGUI timeText;
    public TextMeshProUGUI framesText;
    public TextMeshProUGUI throwsText;
    public TextMeshProUGUI totalScoreText;
    public GameObject optionsPanel;
    
    

    private Score scoreScript;
    private Ball ball;
    
    public GameObject[] pins;
    private Pin pinScript;
    private Vector3[] positions;
    private AudioSource audioSource;

    private void Start()
    {
        pinScript = FindObjectOfType<Pin>();
        pins = GameObject.FindGameObjectsWithTag("Pin");
        ball = FindObjectOfType<Ball>();
        scoreScript = GameObject.Find("ScoreManager").GetComponent<Score>();
        positions = new Vector3[pins.Length];
        audioSource = GetComponent<AudioSource>();
        audioSource.Play();
    }

    private void Update()
    {
        framesText.text = "Frame: " + frameCounter.ToString();
        throwsText.text = "Throws: " + ball._throwsCount.ToString();
        totalScoreText.text = "Total Score: " + scoreScript.totalScore.ToString();
        timeText.text = "Timer: " + timeBar.value.ToString("F0");
        CountPins();
        TimerDown();
        RestartGame();
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

    public void ResetTimer()
    {
        if (timeBar.value == 0)
        {
            timeBar.value = 20;
            TimerDown();
        }
    }

    public void CountPins()
    {
        for (int i = 0; i < pins.Length; i++)
        {
            if (pins[i].transform.eulerAngles.z > 50 && pins[i].transform.eulerAngles.z < 355 && pins[i].activeSelf)
            {
                scoreScript._currentScore++;
                pins[i].SetActive(false);
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
        FrameSystem();
    }


    public void FrameSystem()
    {
        if (scoreScript.isNextFrame == true)
        {
            frameCounter++;
            frames[frameCounter] = frameCounter;
        }        
    }

    private void RestartGame()
    {
        if (scoreScript.isGameOver == true)
        {
            Debug.Log("GameEnded");
            SceneManager.LoadScene(0);

        }
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
    }

}
