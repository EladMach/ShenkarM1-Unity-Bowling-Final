using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;


public class Score : MonoBehaviour
{
    [Header("Variables")]
    private int startScore;
    public int _currentScore;
    public int player1Score;
    public int player2Score;
    public int totalScore;
    public int[] frameScore;
    public bool isGameOver = false;
    public bool isNextFrame = false;

    [Header("UI Elements")]
    public TextMeshProUGUI player1ScoreText;
    public TextMeshProUGUI player2ScoreText;
    public TextMeshProUGUI player1winText;
    public TextMeshProUGUI player2winText;
    public Image spriteImage;


    private GameManager gameManager;
    private Ball ball;
    private AudioSource audioSource;
    

    private void Start()
    {   
        startScore = 0; totalScore = 0;

        gameManager = FindObjectOfType<GameManager>();
        audioSource = GetComponent<AudioSource>();
        ball = FindObjectOfType<Ball>();
        
        PlayerPrefs.SetInt("StartScore", startScore);
        PlayerPrefs.Save();
    }

    private void Update()
    {
        FramesSystem();
        CalculateFinalScore();
        HighScore();
        PlayerPrefs.SetInt("CurrentScore", _currentScore);
        Player1Score();
        Player2Score();
    }

    public void FramesSystem()
    {
        Frame1();
        Frame2();
        Frame3();
        Frame4();
        Frame5();
        Frame6();
        Frame7();
        Frame8();
        Frame9();
        Frame10();
    }


    public void Frame1()
    {
        player1ScoreText.text = "Player 1 Score: " + player1Score.ToString();

        if (ball._throwsCount == 1 && isNextFrame)
        {
            frameScore[0] = PlayerPrefs.GetInt("CurrentScore", _currentScore);
            
        }
        if (ball._throwsCount == 2 && isNextFrame)
        { 
            ResetScore();
            gameManager.ResetPins();  
            gameManager.frameCounter++;
            gameManager.player1NameText.gameObject.SetActive(false);
            gameManager.player2NameText.gameObject.SetActive(true);

            if (frameScore[0] == 10)
            {
                Debug.Log("Spare!");
                StartCoroutine(SpareImage());
                audioSource.Play();
            }
            
        }
        
    }

    public void Frame2()
    {
        player2ScoreText.text = "Player 2 Score: " + player2Score.ToString();

        if (ball._throwsCount == 3 && isNextFrame)
        {
            frameScore[1] = PlayerPrefs.GetInt("CurrentScore", _currentScore);
            
        }
        if (ball._throwsCount == 4 && isNextFrame)
        { 
            ResetScore();
            gameManager.ResetPins();
            gameManager.frameCounter++;
            gameManager.player1NameText.gameObject.SetActive(true);
            gameManager.player2NameText.gameObject.SetActive(false);

            if (frameScore[1] == 10)
            {
                Debug.Log("Spare!");
                StartCoroutine(SpareImage());
                audioSource.Play();
            }
        }
    }

    public void Frame3()
    {
        player1ScoreText.text = "Player 1 Score: " + player1Score.ToString();

        if (ball._throwsCount == 5 && isNextFrame)
        {
            frameScore[2] = PlayerPrefs.GetInt("CurrentScore", _currentScore);   
        }
        if (ball._throwsCount == 6 && isNextFrame)
        {
            ResetScore();
            gameManager.ResetPins();
            gameManager.frameCounter++;
            gameManager.player1NameText.gameObject.SetActive(false);
            gameManager.player2NameText.gameObject.SetActive(true);

            if (frameScore[2] == 10)
            {
                Debug.Log("Spare!");
                StartCoroutine(SpareImage());
                audioSource.Play();
            }
        }
        
    }

    public void Frame4()
    {
        player2ScoreText.text = "Player 2 Score: " + player2Score.ToString();

        if (ball._throwsCount == 7 && isNextFrame)
        {
            frameScore[3] = PlayerPrefs.GetInt("CurrentScore", _currentScore);           
        }
        if (ball._throwsCount == 8 && isNextFrame)
        {
            ResetScore();
            gameManager.ResetPins();
            gameManager.frameCounter++;
            gameManager.player1NameText.gameObject.SetActive(true);
            gameManager.player2NameText.gameObject.SetActive(false);

            if (frameScore[3] == 10)
            {
                Debug.Log("Spare!");
                StartCoroutine(SpareImage());
                audioSource.Play();
            }
        }
        
    }

    public void Frame5()
    {
        player1ScoreText.text = "Player 1 Score: " + player1Score.ToString();

        if (ball._throwsCount == 9 && isNextFrame)
        {
            frameScore[4] = PlayerPrefs.GetInt("CurrentScore", _currentScore);
        }
        if (ball._throwsCount == 10 && isNextFrame)
        {
            ResetScore();
            gameManager.ResetPins();
            gameManager.frameCounter++;
            gameManager.player1NameText.gameObject.SetActive(false);
            gameManager.player2NameText.gameObject.SetActive(true);

            if (frameScore[4] == 10)
            {
                Debug.Log("Spare!");
                StartCoroutine(SpareImage());
                audioSource.Play();
            }
        }
    }

    public void Frame6()
    {
        player2ScoreText.text = "Player 2 Score: " + player2Score.ToString();

        if (ball._throwsCount == 11 && isNextFrame)
        {
            frameScore[5] = PlayerPrefs.GetInt("CurrentScore", _currentScore);    
        }
        if (ball._throwsCount == 12 && isNextFrame)
        {
            ResetScore();
            gameManager.ResetPins();
            gameManager.frameCounter++;
            gameManager.player1NameText.gameObject.SetActive(true);
            gameManager.player2NameText.gameObject.SetActive(false);

            if (frameScore[5] == 10)
            {
                Debug.Log("Spare!");
                StartCoroutine(SpareImage());
                audioSource.Play();
            }
        }
    }

    public void Frame7()
    {
        player1ScoreText.text = "Player 1 Score: " + player1Score.ToString();

        if (ball._throwsCount == 13 && isNextFrame)
        {
            frameScore[6] = PlayerPrefs.GetInt("CurrentScore", _currentScore);
        }
        if (ball._throwsCount == 14 && isNextFrame)
        {
            ResetScore();
            gameManager.ResetPins();
            gameManager.frameCounter++;
            gameManager.player1NameText.gameObject.SetActive(false);
            gameManager.player2NameText.gameObject.SetActive(true);

            if (frameScore[6] == 10)
            {
                Debug.Log("Spare!");
                StartCoroutine(SpareImage());
                audioSource.Play();
            }
        }
    }

    public void Frame8()
    {
        player2ScoreText.text = "Player 2 Score: " + player2Score.ToString();

        if (ball._throwsCount == 15 && isNextFrame)
        {
            frameScore[7] = PlayerPrefs.GetInt("CurrentScore", _currentScore);
        }
        if (ball._throwsCount == 16 && isNextFrame)
        {
            ResetScore();
            gameManager.ResetPins();
            gameManager.frameCounter++;
            gameManager.player1NameText.gameObject.SetActive(true);
            gameManager.player2NameText.gameObject.SetActive(false);

            if (frameScore[7] == 10)
            {
                Debug.Log("Spare!");
                StartCoroutine(SpareImage());
                audioSource.Play();
            }
        }
    }

    public void Frame9()
    {
        player1ScoreText.text = "Player 1 Score: " + player1Score.ToString();

        if (ball._throwsCount == 17 && isNextFrame)
        {
            frameScore[8] = PlayerPrefs.GetInt("CurrentScore", _currentScore);

        }
        if (ball._throwsCount == 18 && isNextFrame)
        {
            ResetScore();
            gameManager.ResetPins();
            gameManager.frameCounter++;
            gameManager.player1NameText.gameObject.SetActive(false);
            gameManager.player2NameText.gameObject.SetActive(true);

            if (frameScore[8] == 10)
            {
                Debug.Log("Spare!");
                StartCoroutine(SpareImage());
                audioSource.Play();
            }
        }
    }

    public void Frame10()
    {
        player2ScoreText.text = "Player 2 Score: " + player2Score.ToString();

        if (ball._throwsCount == 19 && isNextFrame)
        {
            frameScore[9] = PlayerPrefs.GetInt("CurrentScore", _currentScore);
        }
        if (ball._throwsCount == 20 && isNextFrame)
        {
            gameManager.player1NameText.gameObject.SetActive(true);
            gameManager.player2NameText.gameObject.SetActive(false);
            
            if (frameScore[9] == 10)
            {
                Debug.Log("Spare!");
                StartCoroutine(SpareImage());
                audioSource.Play();
            }
            gameManager.GameOver();
        }
    }

    public void ResetScore()
    {
        if (isNextFrame == true)
        {
            _currentScore = startScore;
            isNextFrame = false;
        } 
    }
    
    public void CalculateFinalScore()
    {
        totalScore = frameScore[0] + frameScore[1] + frameScore[2] + frameScore[3] + frameScore[4] + frameScore[5] + frameScore[6] + frameScore[7] + frameScore[8] + frameScore[9];

        PlayerPrefs.SetInt("FinalScore", totalScore);
    }

    public void Player1Score()
    {
        player1Score = frameScore[0] + frameScore[2] + frameScore[4] + frameScore[6] + frameScore[8];
    }
    public void Player2Score()
    {
        player2Score = frameScore[1] + frameScore[3] + frameScore[5] + frameScore[7] + frameScore[9];
    }


    public void HighScore()
    {
        if (PlayerPrefs.GetInt("HighScore") < totalScore)
        {
            PlayerPrefs.SetInt("HighScore", totalScore);
        }
    }

    public void EndGame()
    {
        if (player1Score > player2Score)
        {
            player1winText.gameObject.SetActive(true);
        }
        if (player1Score < player2Score)
        {
            player2winText.gameObject.SetActive(true);
        }
    }

    IEnumerator SpareImage()
    {
        spriteImage.gameObject.SetActive(true);
        yield return new WaitForSeconds(2f);
        spriteImage.gameObject.SetActive(false);
        yield return new WaitForSeconds(2f);
    }

}
