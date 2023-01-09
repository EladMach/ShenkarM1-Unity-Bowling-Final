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

    [Header("UI Elements")]
    public Image fillImage;
    public Slider slider;
    public TextMeshProUGUI powerText;


    private void Start()
    {
        slider = GameObject.Find("PowerBar").GetComponent<Slider>();
        slider.value = Mathf.Clamp(slider.value, 0.0f, 10.0f);
    }

    private void Update()
    {
        PowerBar();
        powerValue = slider.value;

    }


    public void PowerBar()
    {
        StartCoroutine(PowerBarUp());   

        powerText.text = "Power: " + slider.value.ToString("F0");
        
        if (isCoroutineActive == false)
        {
            throwPower = powerValue;
        }
    }
    
    IEnumerator PowerBarUp()
    {
        if (isCoroutineActive == true)
        {
            if (isPowerUp == true)
            {
                slider.value += fillSpeed * Time.deltaTime;
                yield return new WaitForSeconds(2.0f);
                isPowerUp = false;
            }

            if (isPowerUp == false)
            {
                slider.value -= fillSpeed * Time.deltaTime;
                yield return new WaitForSeconds(2.0f);
                isPowerUp = true;
            }
        }
 
    }

}  
