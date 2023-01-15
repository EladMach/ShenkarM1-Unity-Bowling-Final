using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
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
    private void Update()
    {
        SpawnNextPins();
        DestroyPins();
    }

    public void SpawnStartPins()
    {
        Instantiate(pinsPrefab, startingPosition, Quaternion.identity);    
    }

    public void SpawnNextPins()
    {

        if (isSpawning == true && gameManager.turns == 3)
        {
            Instantiate(pinsPrefab, startingPosition, Quaternion.identity);
            isSpawning = false;
        }
        
    }

    public void DestroyPins()
    {
        if (isSpawning == false && gameManager.turns == 2)
        {
            Destroy(pinsPrefab.gameObject);
        }
    }

    
   

    

}
