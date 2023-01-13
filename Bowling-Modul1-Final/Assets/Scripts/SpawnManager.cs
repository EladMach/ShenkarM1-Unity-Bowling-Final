using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    private GameManager gameManager;

    public GameObject pinsPrefab;

    private void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
    }


}
