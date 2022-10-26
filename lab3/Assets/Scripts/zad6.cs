using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class zad6 : MonoBehaviour
{
    Transform target;
    float smoothTime = 0.3f;
    float yVelocity = 0.5f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float newPosition = Mathf.SmoothDamp(transform.position.y, target.position.y, ref yVelocity, smoothTime);
        transform.position = new Vector3(transform.position.x, newPosition, transform.position.z);

    }
}
