using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using TMPro;

public class Power : MonoBehaviour
{
    [Header("Variables")]
    public bool isPowerUp = true;
    public float powerValue;
    public float throwPower;
    public float fillSpeed = 20.0f;
    public bool isCoroutineActive = true;
    
    private Ball ball;

    [Header("UI Elements")]
    public Image fillImage;
    public Slider slider;
    public TextMeshProUGUI powerText;


    private void Start()
    {
        slider = GameObject.Find("PowerBar").GetComponent<Slider>();
        slider.value = Mathf.Clamp(slider.value, 0.0f, 10.0f);
        ball = FindObjectOfType<Ball>();

        
    }

    private void Update()
    {   
        powerValue = slider.value;
        powerText.text = "Power: " + powerValue.ToString("F0");

        StartCoroutine(PowerBarUp());
        StartCoroutine(PowerBarDown());
    }

    public IEnumerator PowerBarUp()
    {
        while (isPowerUp)
        {
            slider.value += fillSpeed * Time.deltaTime;
            yield return new WaitForSeconds(2.0f);
            isPowerUp = false;
        }

    }
    public IEnumerator PowerBarDown()
    {
        while (isPowerUp == false)
        {
            slider.value -= fillSpeed * Time.deltaTime;
            yield return new WaitForSeconds(2.0f);
            isPowerUp = true;
        }
    }

  
}  
