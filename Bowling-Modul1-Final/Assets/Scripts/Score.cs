using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using TMPro;

public class Score : MonoBehaviour
{
   
    public int _currentScore;
    public int _score;
    public GameObject[] pinPrefab;
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
            Destroy(pinPrefab[0]);
        }
        if (other.CompareTag("Pin2"))
        {
            Debug.Log(other.tag);
            _score++;
            Destroy(pinPrefab[1]);
        }
        if (other.CompareTag("Pin3"))
        {
            Debug.Log(other.tag);
            _score++;
            Destroy(pinPrefab[2]);
        }
        if (other.CompareTag("Pin4"))
        {
            Debug.Log(other.tag);
            _score++;
            Destroy(pinPrefab[3]);
        }
        if (other.CompareTag("Pin5"))
        {
            Debug.Log(other.tag);
            _score++;
            Destroy(pinPrefab[4]);
        }
        if (other.CompareTag("Pin6"))
        {
            Debug.Log(other.tag);
            _score++;
            Destroy(pinPrefab[5]);
        }
        if (other.CompareTag("Pin7"))
        {
            Debug.Log(other.tag);
            _score++;
            Destroy(pinPrefab[6]);
        }
        if (other.CompareTag("Pin8"))
        {
            Debug.Log(other.tag);
            _score++;
            Destroy(pinPrefab[7]);
        }
        if (other.CompareTag("Pin9"))
        {
            Debug.Log(other.tag);
            _score++;
            Destroy(pinPrefab[8]);
        }
        if (other.CompareTag("Pin10"))
        {
            Debug.Log(other.tag);
            _score++;
            Destroy(pinPrefab[9]);
        }

    }

    private IEnumerator WaitCoroutine()
    {
        yield return new WaitForSeconds(3.0f);
    }
   

}
