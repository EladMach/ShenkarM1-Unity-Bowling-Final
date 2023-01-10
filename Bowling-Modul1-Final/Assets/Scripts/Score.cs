using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using TMPro;

public class Score : MonoBehaviour
{
   
    public int _currentScore;
    public int _score;

    public TextMeshProUGUI scoreText;

    private void Start()
    {
        scoreText.text = "Score " + _score;
    }

    private void Update()
    {
        _currentScore = _score;
        scoreText.text = "Score: " + _currentScore.ToString();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Pin1"))
        {
            Debug.Log(other.tag);
            _score++;
        }
        if (other.CompareTag("Pin2"))
        {
            Debug.Log(other.tag);
            _score++;
        }
        if (other.CompareTag("Pin3"))
        {
            Debug.Log(other.tag);
            _score++;
        }
        if (other.CompareTag("Pin4"))
        {
            Debug.Log(other.tag);
            _score++;
        }
        if (other.CompareTag("Pin5"))
        {
            Debug.Log(other.tag);
            _score++;
        }
        if (other.CompareTag("Pin6"))
        {
            Debug.Log(other.tag);
            _score++;
        }
        if (other.CompareTag("Pin7"))
        {
            Debug.Log(other.tag);
            _score++;
        }
        if (other.CompareTag("Pin8"))
        {
            Debug.Log(other.tag);
            _score++;
        }
        if (other.CompareTag("Pin9"))
        {
            Debug.Log(other.tag);
            _score++;
        }
        if (other.CompareTag("Pin10"))
        {
            Debug.Log(other.tag);
            _score++;
        }

    }

   

}
