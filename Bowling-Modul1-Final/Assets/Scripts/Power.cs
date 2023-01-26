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
    
    private Ball ball;

    [Header("UI Elements")]
    public Image fillImage;
    public Slider powerBarSlider;
    public TextMeshProUGUI powerText;


    private void Start()
    {   
        powerBarSlider = GameObject.Find("PowerBar").GetComponent<Slider>();
        powerBarSlider.value = Mathf.Clamp(powerBarSlider.value, 0.0f, 10.0f);
        ball = FindObjectOfType<Ball>();
    }

    private void Update()
    {   
        powerValue = powerBarSlider.value;
        powerText.text = "Power: " + powerValue.ToString("F0");

        StartCoroutine(PowerBarUp());
        StartCoroutine(PowerBarDown());

    }

    public IEnumerator PowerBarUp()
    {
        while (isPowerUp)
        {
            powerBarSlider.value += fillSpeed * Time.deltaTime;
            yield return new WaitForSeconds(2.0f);
            isPowerUp = false;
        }
    }
    public IEnumerator PowerBarDown()
    {
        while (isPowerUp == false)
        {
            powerBarSlider.value -= fillSpeed * Time.deltaTime;
            yield return new WaitForSeconds(2.0f);
            isPowerUp = true;
        }
    }
  
}  
