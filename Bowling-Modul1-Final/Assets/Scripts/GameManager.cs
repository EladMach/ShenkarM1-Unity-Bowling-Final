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
    public TextMeshProUGUI framesText;

    private Score scoreScript;
    private Ball ball;
    
    public GameObject[] pins;

   
    private void Start()
    {
        frames = 0;
        pins = GameObject.FindGameObjectsWithTag("Pin");
        ball = FindObjectOfType<Ball>();
        scoreScript = GameObject.Find("ScoreManager").GetComponent<Score>();  
    }

    private void Update()
    {          
        StartCoroutine(TimerDown());
        framesText.text = "Frame: " + frames;
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
            if (pins[i].transform.eulerAngles.z > 30 && pins[i].transform.eulerAngles.z < 355 && pins[i].activeSelf)
            {
                scoreScript._currentScore++;
                pins[i].SetActive(false);              
            }
        }

    }

    public void ResetPins()
    {
        if (ball._throws == 2)
        {
            for (int i = 0; i < pins.Length; i++)
            {
                pins[i].GetComponent<Pin>().ResetPin();
                pins[i].SetActive(true);   
            }
    
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
