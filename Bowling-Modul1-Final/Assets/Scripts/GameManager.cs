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
    
    public GameObject[] pins;

   
    private void Start()
    {
        //pins = GameObject.FindGameObjectsWithTag("Pin");
        ball = FindObjectOfType<Ball>();
        scoreScript = GameObject.Find("ScoreManager").GetComponent<Score>();
        
        turns = Mathf.Clamp(turns, 0, 20);
        
    }

    private void Update()
    {          
        StartCoroutine(TimerDown());
        turnsText.text = "Turn: " + turns;
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
        
        yield return new WaitForSeconds(1.0f);
    }

    public void NextTurn()
    {       
        turns = ball._throws;  
    }

    public void ResetPins()
    {
        foreach (GameObject pin in pins)
        {
            pin.GetComponent<Pin>().ResetPin();
            pin.SetActive(true);
        }
    }

    

    //private void RestartGame()
    //{
    //    if (turns == 20)
    //    {
    //        SceneManager.LoadScene(0);
    //    }
    //}

}
