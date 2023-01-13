using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pin : MonoBehaviour
{
    private Rigidbody rb;
    private Ball ball;
    private GameManager gameManager;
    private Vector3 startingPosition;
    private AudioSource audioSource;


    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();
        startingPosition = transform.position;
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        ball = FindObjectOfType<Ball>();
        audioSource = gameObject.GetComponent<AudioSource>();
        

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
        if (ball._isThrown == true)
        {
            rb.constraints = RigidbodyConstraints.None;
        }
  
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Ball")
        {
            audioSource.Play();    
        }
    }


}
