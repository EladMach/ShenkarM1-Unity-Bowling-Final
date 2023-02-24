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
    public float fillSpeed = 30.0f;

    [Header("UI Elements")]
    public Image fillImage;
    public Slider powerBarSlider;
    public TextMeshProUGUI powerText;

    private Ball ball;

    private void Start()
    {   
        ball = FindObjectOfType<Ball>();
        powerBarSlider = GameObject.Find("PowerBar").GetComponent<Slider>();
        powerBarSlider.value = Mathf.Clamp(powerBarSlider.value, 0.0f, 10.0f);
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
            yield return new WaitForSeconds(1.5f);
            isPowerUp = false;
        }
    }
    public IEnumerator PowerBarDown()
    {
        while (isPowerUp == false)
        {
            powerBarSlider.value -= fillSpeed * Time.deltaTime;
            yield return new WaitForSeconds(1.5f);
            isPowerUp = true;
        }
    }
  
}  
