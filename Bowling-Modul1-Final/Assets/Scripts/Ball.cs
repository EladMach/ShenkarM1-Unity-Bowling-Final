using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using JetBrains.Annotations;

public class Ball : MonoBehaviour
{
    private Rigidbody rb;
    private Vector3 startingPosition;
    private Pin pinScript;
    private GameManager gameManager;
    private Power powerScript;
    private AudioSource audioSource;
    private SpawnManager spawnManager;

    [Header("GameObjects")]
  
    [Header("Variables")]
    public float _powerMultiplier = 150f;
    public float _movementSpeed = 30.0f;
    public bool _isThrown = false;
    public bool _isMoving = false;
    public int _throws;

    

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        startingPosition = new Vector3(0, 0.35f, -7.5f);       
        powerScript = FindObjectOfType<Power>();
        pinScript = FindObjectOfType<Pin>();
        gameManager = FindObjectOfType<GameManager>();
        spawnManager = FindObjectOfType<SpawnManager>();
        audioSource = GetComponent<AudioSource>();
        startingPosition = new Vector3(0, 0.35f, -10f);
    }

    private void Update()
    {
        Throw();
        StartCoroutine(BallReset());

    }
  
    public void Throw()
    {
        if (_isMoving == false)
        {
            transform.Translate(Vector3.right * Input.GetAxis("Horizontal") * _movementSpeed * Time.deltaTime);
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce(Vector3.forward * powerScript.powerValue * _powerMultiplier);
            audioSource.Play();
            _isThrown = true; 
            _isMoving = true;
            _throws = _throws + 1;
        }

    }

    public IEnumerator BallReset()
    {
        if (transform.position.z >= -4.0f)
        {
            yield return new WaitForSeconds(2.0f);
            _isThrown = false;
            _isMoving = false;                       
            transform.position = startingPosition;
            gameManager.NextTurn();
        }

        yield return null;
    }

    

}
