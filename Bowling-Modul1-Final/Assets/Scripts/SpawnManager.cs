using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    private GameManager gameManager;
    private Vector3 startingPosition;
    public GameObject pinsPrefab;

    public bool isSpawning = true;

    private void Start()
    {
        startingPosition = transform.position;
        gameManager = FindObjectOfType<GameManager>();  
    }
    private void Update()
    {
        
    }


    public void SpawnNextPins()
    {

        if (isSpawning == true)
        {
            Instantiate(pinsPrefab, startingPosition, Quaternion.identity);
            isSpawning = false;
        }

    }


}
