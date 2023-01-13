using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    private GameManager gameManager;
    private Vector3 startingPosition;
    public GameObject pinsPrefab;

    private void Start()
    {
        startingPosition = transform.position;
        gameManager = FindObjectOfType<GameManager>();
        SpawnPins();
    }

    public void SpawnPins()
    {
        Instantiate(pinsPrefab, startingPosition, Quaternion.identity);
    }

    

}
