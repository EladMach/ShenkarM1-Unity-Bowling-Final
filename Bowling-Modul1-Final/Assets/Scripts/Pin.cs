using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pin : MonoBehaviour
{
    private Rigidbody rb;
    private Ball ball;
    private GameManager gameManager;
    private Vector3 initialPosition;
    private Quaternion initialRotation;

    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();
        
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        ball = FindObjectOfType<Ball>();  
    
        initialPosition = transform.position;
        initialRotation = Quaternion.identity;
    }
  
    public void ResetPin()
    {
        transform.position = initialPosition;
        transform.rotation = initialRotation;
        rb.velocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;     
    }


}
