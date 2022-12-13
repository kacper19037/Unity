using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarLights : MonoBehaviour
{
    public WheelCollider frontDriverW, frontPassengerW;
    private CarController carController;
    public Light left;
    public Light right;
    public Light up1;
    public Light up2;
    public Light up3;
    public Light leftReverse;
    public Light rightReverse;

    void Start()
    {
        carController = GetComponent<CarController>();
    }
    void Update()
    {
       
        if(Input.GetKey(KeyCode.S) && carController.reverse == false)
        {
            left.intensity = 10f;
            right.intensity = 10f;
            up1.intensity = 10f;
            up2.intensity = 10f;
            up3.intensity = 10f;
        }
        else if (carController.reverse == true)
        {
            left.intensity = 0f;
            right.intensity = 0f;
            up1.intensity = 0f;
            up2.intensity = 0f;
            up3.intensity = 0f;
            leftReverse.intensity = 10f;
            rightReverse.intensity = 10f;
        }
        else
        {
            left.intensity = 0f;
            right.intensity = 0f;
            up1.intensity = 0f;
            up2.intensity = 0f;
            up3.intensity = 0f;
            leftReverse.intensity = 0f;
            rightReverse.intensity = 0f;
        }
        
    }
}
