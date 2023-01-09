using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Power : MonoBehaviour
{
    public Image fillImage;
    private Slider slider;

    public bool isPowerUp = true;
    
    public float fillSpeed = 0.5f;

    private void Start()
    {
        slider = gameObject.GetComponent<Slider>();
        slider.value = Mathf.Clamp(slider.value, 0.0f, 1.0f);

    }

    private void Update()
    {
        PowerBar();
    }


    void PowerBar()
    {
        StartCoroutine(PowerBarUp());       
    }
    
    IEnumerator PowerBarUp()
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

        yield return new WaitForSeconds(1.0f);
    }

}  
