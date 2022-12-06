using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class zad1 : MonoBehaviour
{
    public float elevatorSpeed = 2f;
    private bool isRunning = false;
    public float distance = 61.5f;
    private bool isRunningForward = true;
    private bool isRunningBackward = false;
    private float backwardPosition;
    private float forwardPosition;
    public Transform oldParent;

    void Start()
    {
        forwardPosition = transform.position.z + distance;
        backwardPosition = transform.position.z;
    }

    void Update()
    {
        if (isRunningForward && transform.position.z >= forwardPosition)
        {
            isRunning = false;
        }
        else if (isRunningBackward && transform.position.z <= backwardPosition)
        {
            isRunning = false;
        }

        if (isRunning)
        {
            Vector3 move = transform.forward * elevatorSpeed * Time.deltaTime;
            transform.Translate(move);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("Player wszed³ na windê.");
            // zapamiêtujemy "starego rodzica"
            oldParent = other.gameObject.transform.parent;
            // skrypt przypisany do windy, ale other mo¿e byæ innym obiektem
            other.gameObject.transform.parent = transform;
            if (transform.position.z >= forwardPosition)
            {
                isRunningBackward = true;
                isRunningForward = false;
                elevatorSpeed = -elevatorSpeed;
            }
            else if (transform.position.z <= backwardPosition)
            {
                isRunningForward = true;
                isRunningBackward = false;
                elevatorSpeed = Mathf.Abs(elevatorSpeed);
            }
            isRunning = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("Player zszed³ z windy.");
            other.gameObject.transform.parent = oldParent;
        }
    }
}
