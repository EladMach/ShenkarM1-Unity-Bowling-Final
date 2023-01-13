using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PinScoreTrigger : MonoBehaviour
{
    public GameObject pinPrefab;

    private void Start()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "ScoreGround")
        {
            Destroy((pinPrefab), 2.0f);
        }
    }
}
