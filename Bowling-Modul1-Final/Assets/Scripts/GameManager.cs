using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using Unity.VisualScripting;
using TMPro.Examples;

public class GameManager : MonoBehaviour
{
    [Header("Variables")]
    public int frames; 
    private bool isTimerOn = true;
    private float fillSpeed = 1.0f;
    

    [Header("UI Elements")]
    public Slider timeBar;
    public TextMeshProUGUI timeText;
    public TextMeshProUGUI turnsText;

    private Score scoreScript;
    private Ball ball;
    
    public GameObject[] pins;

   
    private void Start()
    {
        frames = 1;
        pins = GameObject.FindGameObjectsWithTag("Pin");
        ball = FindObjectOfType<Ball>();
        scoreScript = GameObject.Find("ScoreManager").GetComponent<Score>();  
    }

    private void Update()
    {          
        StartCoroutine(TimerDown());
        turnsText.text = "Turn: " + frames;
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
        foreach (GameObject pin in pins)
        {
            if (pin.transform.eulerAngles.z > 5 && pin.transform.eulerAngles.z < 355 && pin.activeSelf)
            {
                scoreScript.score++;
                scoreScript._currentScore = scoreScript.score;
                //pin.GetComponent<Pin>().ResetPin();
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
            ball.BallReset();             
        }
    }

    public void UpdateFrame()
    {
        frames = frames + 1;
    }


    //private void RestartGame()
    //{
    //    if (turns == 20)
    //    {
    //        SceneManager.LoadScene(0);
    //    }
    //}

}
