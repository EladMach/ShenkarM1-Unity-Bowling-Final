using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class Score : MonoBehaviour
{
    [Header("Variables")]
    public int _currentScore;
    public int _score;
    

    [Header("UI Elements")]
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
        if (other.CompareTag("ScoreTrigger"))
        {
            Debug.Log("Pin Fell");
            _score++;

        }
     
    }

   

}
