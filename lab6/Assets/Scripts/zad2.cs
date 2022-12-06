using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class zad2 : MonoBehaviour
{


    void Start()
    {
       
    }

    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("Player otwiera drzwi.");
            var rotationVector = transform.rotation.eulerAngles;
            rotationVector.y = 90;
            transform.rotation = Quaternion.Euler(rotationVector);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("Player zamyka drzwi.");
            var rotationVector = transform.rotation.eulerAngles * Time.deltaTime;
            rotationVector.y = 0;
            transform.rotation = Quaternion.Euler(rotationVector);
        }
    }
}
