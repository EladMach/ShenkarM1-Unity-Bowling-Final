using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Ball : MonoBehaviour
{
    private Rigidbody rb;
    private Vector3 startingPosition;
    private Pin pinScript;

    [Header("GameObjects")]
    private Power powerScript;
    
    [Header("Variables")]
    public float _powerMultiplier = 150f;
    public float _movementSpeed = 30.0f;
    public bool _isThrown = false;

    private void Start()
    {
        rb = GetComponent<Rigidbody>(); 
        startingPosition = transform.position;
        powerScript = FindObjectOfType<Power>();
        pinScript = FindObjectOfType<Pin>();
    }

    private void Update()
    {
        Throw();
        ResetBall();
    }
  
    public void Throw()
    {

        if (Input.GetKeyDown(KeyCode.Space))
        {

            _isThrown = true;
            rb.AddForce(Vector3.forward * powerScript.powerValue * _powerMultiplier);

        }

        transform.Translate(Vector3.right * Input.GetAxis("Horizontal") * _movementSpeed * Time.deltaTime);
    }

    void ResetBall()
    {
        if (_isThrown == true && rb.IsSleeping())
        {
            //ScenerManager.LoadScene(0);
        }
    }
    
}
