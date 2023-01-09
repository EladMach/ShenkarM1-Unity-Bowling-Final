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
    private Pin pinScript;
    


    private void Start()
    {
             
    }

    private void Update()
    {
        TimerDown();
        timeText.text = "Timer: " + timeBar.value.ToString("F0");
    }
    void TimerDown()
    {
        timeBar.value -= fillSpeed * Time.deltaTime;
        if (timeBar.value == 0)
        {
            Debug.Log("Times Up!");
            //load next turn
        }
    }

    
}
