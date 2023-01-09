using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pin : MonoBehaviour
{
    public Rigidbody rb;
    private Ball ball;
    private GameManager gameManager;

    
    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();
        ball = GameObject.Find("Ball").GetComponent<Ball>();
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
  
    }

    // Update is called once per frame
    void Update()
    {

    }

    



}
