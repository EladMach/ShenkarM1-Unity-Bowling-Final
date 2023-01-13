using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [Header("Variables")]
    
    private bool isTimerOn = true;
    private float fillSpeed = 1.0f;

    [Header("UI Elements")]
    public Slider timeBar;
    public TextMeshProUGUI timeText;

    private Ball ball;


    private void Start()
    {
        ball = FindObjectOfType<Ball>();    
  
    }

    private void Update()
    {          
        StartCoroutine(TimerDown());

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
            Debug.Log("Times Up!");
        }

        if (ball._isThrown == false)
        {
            isTimerOn = true;     
        }

        yield return new WaitForSeconds(timeBar.value);
    }

}
