using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [Header("Variables")]
    

    [Header("UI Elements")]
    public Slider timeBar;
    public TextMeshProUGUI timeText;


    private float fillSpeed = 1.0f;
    private bool isTimerOn = true;
    private Ball ball;
  

    private void Start()
    {
        ball = FindObjectOfType<Ball>();    
    }

    private void Update()
    {        
        StartTimer();
        StopTimer();

        timeText.text = "Timer: " + timeBar.value.ToString("F0");
    }
    public IEnumerator TimerDown()
    {
        if (isTimerOn == true)
        {
            timeBar.value -= fillSpeed * Time.deltaTime;
        }

        yield return null;
    }


    public void StartTimer()
    {
        StartCoroutine(TimerDown());
    }
    public void StopTimer()
    {
        if (ball._isThrown == true)
        {
            isTimerOn = false;
            StopCoroutine(TimerDown());
        }

        if (timeBar.value == 0)
        {
            isTimerOn = false;
            StopCoroutine(TimerDown());
            Debug.Log("Times Up!");
            
        }
    }
    
}
