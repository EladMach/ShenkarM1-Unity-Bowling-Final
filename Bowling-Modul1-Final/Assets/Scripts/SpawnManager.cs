using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    private GameManager gameManager;
    public Vector3 startingPosition;
    public GameObject[] pinsPrefab;

    public bool isSpawning = true;

    

    private void Start()
    {
        startingPosition = transform.position;
        gameManager = FindObjectOfType<GameManager>();
        
    }
    private void Update()
    {
        SpawnPins();
    }


    public void SpawnPins()
    {
        if (isSpawning == true)
        {
            Instantiate(pinsPrefab[0], startingPosition, Quaternion.identity);
            isSpawning = false;
        }
    }

    
}
