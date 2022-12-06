using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class zad3 : MonoBehaviour
{
    public float speed = 2f;
    private bool isRunning = false;
    private bool isRunningForward = false;
    private bool isRunningBackward = false;
    private bool first = false;
    private bool second = false;
    private bool third = false;
    [SerializeField] private Vector3 target1 = new Vector3(-131.2f, 8.24f, -152.4f);
    [SerializeField] private Vector3 target2 = new Vector3(-131.2f, 8.24f, -29.6f);
    [SerializeField] private Vector3 target0 = new Vector3(-53.9f, 8.24f, -152.4f);
    public Transform oldParent;

    void Start()
    {
        
    }

    void Update()
    {
        if (isRunningForward)
        {
            if (Vector3.Distance(transform.position, target1) < 1f)
            {
                first = true;
                second = true;
            }
           
        }
        else if (isRunningBackward)
        {
           
           if (second)
            {
                second = false;
                first= false;
            }
            else if (Vector3.Distance(transform.position, target1) < 1f)
            {
               second = false;
               first = true;
               third = true;
            }
            else if (Vector3.Distance(transform.position, target0) < 1f)
            {
                third = false;
                first = false;
                isRunning = false;
            }
            
        }

        if (isRunning)
        {
            if (first == false)
            {
                transform.position = Vector3.MoveTowards(transform.position, target1, Time.deltaTime * speed);
            }
            else if (second == true)
            {
                transform.position = Vector3.MoveTowards(transform.position, target2, Time.deltaTime * speed);
            }
            else if (third == true)
            {
                transform.position = Vector3.MoveTowards(transform.position, target0, Time.deltaTime * speed);
            }
            
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
            isRunning = true;
            isRunningForward = true;
            isRunningBackward = false;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("Player zszed³ z windy.");
            other.gameObject.transform.parent = oldParent;
            isRunning = true;
            isRunningBackward = true;
            isRunningForward = false;
        }
    }
}
