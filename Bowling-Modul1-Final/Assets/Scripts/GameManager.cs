using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public Slider timeBar;
    private float fillSpeed = 0.2f;
    private void Start()
    {
               
    }

    private void Update()
    {
        TimerDown();
    }
    void TimerDown()
    {
        timeBar.value -= fillSpeed * Time.deltaTime;
    }
}
