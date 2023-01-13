using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    private GameManager gameManager;
    private Vector3 startingPosition;
    public GameObject pinsPrefab;

    public bool isSpawned;

    private void Start()
    {
        startingPosition = transform.position;
        gameManager = FindObjectOfType<GameManager>();
        
    }

    public IEnumerator SpawnPins()
    {
        if (isSpawned)
        {
            Instantiate(pinsPrefab, startingPosition, Quaternion.identity);
            isSpawned = false;
        }
        yield break;
    }

    

}
