using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Turns
{
    Turn1, Turn2, Turn3, Turn4, Turn5, Turn6, Turn7, Turn8, Turn9, Turn10,
}
public class TurnSystem : MonoBehaviour
{
    public Turns turnIndex;

    public int[] turnScore = new int[3];

    private Ball ball;
    private GameManager gameManager;
    private Power powerScript;
    private Score scoreScript;
    private bool isCoroutineActive = true;

    private void Start()
    {
        ball = FindObjectOfType<Ball>();
        powerScript = FindObjectOfType<Power>();
        scoreScript = FindObjectOfType<Score>();
        gameManager = FindObjectOfType<GameManager>();
        
    }

    private void Update()
    {
        StartCoroutine(Turn1());
        
        gameManager = FindObjectOfType<GameManager>();
        
    }

    

    public IEnumerator Turn1()
    {
        if (isCoroutineActive)
        {
            turnIndex = Turns.Turn1;
            turnScore[0] = scoreScript._currentScore;
        }

        if (ball._throws == 2)
        {
            
            isCoroutineActive = false;  
            StartCoroutine(Turn2());
        }

        yield return null;
    }

    public IEnumerator Turn2()
    {
    
         if (ball._throws >= 2 && ball._throws <= 4)
         {
             turnIndex = Turns.Turn2;
             turnScore[1] = scoreScript._currentScore;
         }

         if (ball._throws == 4)
         {    
            StartCoroutine(Turn3());
            StopCoroutine(Turn2());
         }

        yield return null;
    }

    public IEnumerator Turn3()
    {

         if (ball._throws >= 4 && ball._throws <= 6)
         {
             turnIndex = Turns.Turn3;
             turnScore[2] = scoreScript._currentScore;
         }
         
            
        yield return null;
        
    }
}
