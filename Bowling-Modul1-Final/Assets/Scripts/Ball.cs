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
        startingPosition = new Vector3(0, 0.35f, -7.5f);       
        powerScript = FindObjectOfType<Power>();
        pinScript = FindObjectOfType<Pin>();

    }

    private void Update()
    {
        Throw();
        StartCoroutine(BallReset());

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
   

    IEnumerator BallReset()
    {
        if (transform.position.z >= 5.0f)
        {
            yield return new WaitForSeconds(3.0f);
            _isThrown = false;
            transform.position = startingPosition;
        }
        else
        {
            yield return null;
        }
    }



}
