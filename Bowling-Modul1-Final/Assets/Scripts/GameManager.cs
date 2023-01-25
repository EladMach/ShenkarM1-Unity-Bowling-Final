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
    

    [Header("UI Elements")]
    public Slider timeBar;
    public TextMeshProUGUI timeText;
    public TextMeshProUGUI framesText;
    public TextMeshProUGUI throwsText;
    public TextMeshProUGUI totalScoreText;

    private Score scoreScript;
    private Ball ball;
    
    public GameObject[] pins;
    private Pin pinScript;
    private Vector3[] positions;

    private void Start()
    {
        pinScript = FindObjectOfType<Pin>();
        pins = GameObject.FindGameObjectsWithTag("Pin");
        ball = FindObjectOfType<Ball>();
        scoreScript = GameObject.Find("ScoreManager").GetComponent<Score>();
        positions = new Vector3[pins.Length];
    }

    private void Update()
    {          
        StartCoroutine(TimerDown());
        framesText.text = "Frame: " + frameCounter.ToString();
        throwsText.text = "Throws: " + ball._throwsCount.ToString();
        totalScoreText.text = "Total Score: " + scoreScript.totalScore.ToString();
        timeText.text = "Timer: " + timeBar.value.ToString("F0");
        CountPins();
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
        yield return new WaitForSeconds(1.0f);
        
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
            //SceneManager.LoadScene(0);
        }
    }

}
