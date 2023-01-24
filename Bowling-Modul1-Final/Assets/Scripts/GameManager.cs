using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using Unity.VisualScripting;

public class GameManager : MonoBehaviour
{
    [Header("Variables")]
    public int frames = 0;
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
            if (pin.transform.eulerAngles.z > 100 && pin.transform.eulerAngles.z < 355 && ball.transform.position.z >= 8)
            {
                scoreScript._currentScore++;   
                pin.GetComponent<Pin>().ResetPin();
                pin.SetActive(false);
                StartCoroutine(ball.BallReset());
            }
            
        }
    }

    public void NextFrame()
    {
        frames++;
    }


    //private void RestartGame()
    //{
    //    if (turns == 20)
    //    {
    //        SceneManager.LoadScene(0);
    //    }
    //}

}
