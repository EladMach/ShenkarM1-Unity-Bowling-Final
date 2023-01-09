using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Score : MonoBehaviour
{

    public int _score;


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Pin1"))
        {
            Debug.Log(other.tag);
        }
        if (other.CompareTag("Pin2"))
        {
            Debug.Log(other.tag);
        }
        if (other.CompareTag("Pin3"))
        {
            Debug.Log(other.tag);
        }
        if (other.CompareTag("Pin4"))
        {
            Debug.Log(other.tag);
        }
        if (other.CompareTag("Pin5"))
        {
            Debug.Log(other.tag);
        }
        if (other.CompareTag("Pin6"))
        {
            Debug.Log(other.tag);
        }
        if (other.CompareTag("Pin7"))
        {
            Debug.Log(other.tag);
        }
        if (other.CompareTag("Pin8"))
        {
            Debug.Log(other.tag);
        }
        if (other.CompareTag("Pin9"))
        {
            Debug.Log(other.tag);
        }
        if (other.CompareTag("Pin10"))
        {
            Debug.Log(other.tag);
        }



    }



}
