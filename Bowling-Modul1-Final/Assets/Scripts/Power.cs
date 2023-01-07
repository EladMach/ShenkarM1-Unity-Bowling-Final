using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Power : MonoBehaviour
{
    public Image fillImage;
    private Slider slider;
    
    
    public float fillSpeed = 0.5f;

    private void Start()
    {
        slider = gameObject.GetComponent<Slider>();
        slider.value = 0.0f;
    }

    private void Update()
    {
        PowerUp();
        PowerDown();
    }



    void PowerUp()
    {
        if (slider.value == 0.0f)
        {
            slider.value += fillSpeed * Time.deltaTime;
        }

    }

    void PowerDown()
    {
        if (slider.value == 1.0f)
        {
            slider.value -= fillSpeed * Time.deltaTime;
        }
    }

  

}   
