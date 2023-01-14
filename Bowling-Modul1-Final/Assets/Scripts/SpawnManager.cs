using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    private GameManager gameManager;
    private Vector3 startingPosition;
    public GameObject pinsPrefab;

    private bool isSpawning = true;

    private void Start()
    {
        startingPosition = transform.position;
        gameManager = FindObjectOfType<GameManager>();
        SpawnStartPins();
    }

    public void SpawnStartPins()
    {
        Instantiate(pinsPrefab, startingPosition, Quaternion.identity);    
    }

    public void SpawnNextPins()
    {
        if (isSpawning)
        {
            Instantiate(pinsPrefab, startingPosition, Quaternion.identity);
            isSpawning = false;
        }
        
    }

    
   

    

}
