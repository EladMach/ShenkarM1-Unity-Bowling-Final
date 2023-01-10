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
    private Power powerScript;
    private Score scoreScript;
    private void Start()
    {
        ball = FindObjectOfType<Ball>();
        powerScript = FindObjectOfType<Power>();
        scoreScript = FindObjectOfType<Score>();
        
    }

    private void Update()
    {
        StartCoroutine(Turn1());
        StartCoroutine(Turn2());
    }

    

    public IEnumerator Turn1()
    {
        turnIndex = Turns.Turn1;
        turnScore[0] = scoreScript._currentScore;
        if (ball._throws == 2)
        {
            StopCoroutine(Turn1());
        }
        yield return null;
    }

    public IEnumerator Turn2()
    {
        if (ball._throws == 2)
        {   
            turnIndex = Turns.Turn2;
            turnScore[1] = scoreScript._currentScore;
        }

        yield return null;
    }

    public void Turn3()
    {
        turnScore[2] = scoreScript._currentScore;
    }
}
