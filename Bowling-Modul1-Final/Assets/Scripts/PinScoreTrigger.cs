using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PinScoreTrigger : MonoBehaviour
{
    public GameObject pinPrefab;
    private GameManager gameManager;

    private void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
    }

    private void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "ScoreGround")
        {
            Destroy((pinPrefab), 1.5f);
        }
    }

    

    
}
