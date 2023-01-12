using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pin : MonoBehaviour
{
    private Rigidbody rb;
    private Ball ball;
    private GameManager gameManager;
   
    
    
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();     
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        ball = FindObjectOfType<Ball>(); 

    }

    
    void Update()
    {
        FreezePinPosition();
    }

    public void FreezePinPosition()
    {
        if (ball._isThrown == false)
        {
            rb.constraints = RigidbodyConstraints.FreezePositionZ | RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezePositionY;
        }
        else if (ball._isThrown == true)
        {
            rb.constraints = RigidbodyConstraints.None;
        }
    }



}
