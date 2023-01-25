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
    public AudioSource audioSource;
    public AudioClip hitSound;   
    public AudioClip throwSound;


    [Header("GameObjects")]
    
  
    [Header("Variables")]
    public float _powerMultiplier = 150f;
    public float _movementSpeed = 30.0f;
    public bool _isThrown = false;
    public bool _isMoving = false;
    public bool isNextFrame = false;
    public int[] _throws;
    public int _throwsCount;
    public float volume = 0.3f;


    private void Start()
    {
        _throwsCount = 0;
        _throws = new int[20];
        rb = GetComponent<Rigidbody>();
        startingPosition = new Vector3(0, 0.35f, -7.5f);       
        powerScript = FindObjectOfType<Power>();
        pinScript = FindObjectOfType<Pin>();
        gameManager = FindObjectOfType<GameManager>();
        audioSource.clip = hitSound;
        audioSource.clip = throwSound;
        audioSource = GetComponent<AudioSource>();
        startingPosition = new Vector3(0, 0.35f, -10f);    
    }

    private void Update()
    {
        Throw();
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
            audioSource.PlayOneShot(throwSound, volume);
            _isThrown = true; 
            _isMoving = true;   
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("ScoreGround"))
        {
            BallReset();
            isNextFrame = true;
        }
        else
        {
            isNextFrame = false;
        }
    }

    public void BallReset()
    {
        if (transform.position.z >= -4.0f)
        {
            _isThrown = false;
            _isMoving = false;
            transform.position = startingPosition;
            rb.velocity = Vector3.zero;
            rb.angularVelocity = Vector3.zero;
            transform.rotation = Quaternion.identity;
            gameManager.FrameSystem();
            ThrowsSystem();
        }

    }

    public void ThrowsSystem()
    {
        _throwsCount++;
        _throws[_throwsCount] = _throwsCount;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Pin"))
        {
            audioSource.PlayOneShot(hitSound, volume);
        }
    }


}
