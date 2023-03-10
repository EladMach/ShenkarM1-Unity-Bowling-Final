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
    private Score scoreScript;
    private GameManager gameManager;
    private Power powerScript;
    
    [Header("Audio")]
    public AudioSource audioSource;
    public AudioClip hitSound;
    public AudioClip throwSound;

    [Header("Variables")]
    public float _powerMultiplier = 150f;
    public float _movementSpeed = 30.0f;
    public float volume = 0.5f;
    public float delay = 2f;
    public float timer = 0;
    public bool _isThrown = false;
    public bool _isMoving = false;
    public int[] _throws;
    public int _throwsCount;
    

    private void Start()
    {
        _throwsCount = 0;
        _throws = new int[20];
        rb = GetComponent<Rigidbody>();     
        powerScript = FindObjectOfType<Power>();
        pinScript = FindObjectOfType<Pin>();
        gameManager = FindObjectOfType<GameManager>();
        scoreScript = FindObjectOfType<Score>();
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
            transform.position = new Vector3(Mathf.Clamp(transform.position.x, -1.4f, 1.4f), transform.position.y, transform.position.z);
        }

        if (Input.GetKeyDown(KeyCode.Space) || gameManager.timeBar.value == 0)
        {       
            rb.AddForce(Vector3.forward * powerScript.powerValue * _powerMultiplier);
            audioSource.PlayOneShot(throwSound, volume);
            _isThrown = true; 
            _isMoving = true;   
        }
        
    }

    private void OnTriggerStay(Collider other)
    {
        timer += Time.deltaTime;

        if (other.gameObject.CompareTag("ScoreGround") && delay <= timer)
        {
            BallReset();        
            scoreScript.isNextFrame = true;
            timer = 0;
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
            ThrowsSystem();
            scoreScript.isNextFrame = false;
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
