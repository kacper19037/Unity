using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarSound : MonoBehaviour
{
    private AudioSource sound;
    public float minPitch = 0.3f;
    private float pitchFromCar;
    public Rigidbody target;
    private CarController carController;
    private Timer timer;
    [Header("Start time controller")]
    public GameObject TimerManager;
    void Start()
    {
        sound = GetComponent<AudioSource>();
        carController = GetComponent<CarController>();
        sound.pitch = minPitch;
        TimerManager = GameObject.FindGameObjectWithTag("Time");
        timer = TimerManager.GetComponent<Timer>();
    }

    
    void Update()
    {
        if (carController.frontDriverW.motorTorque > 0 && carController.gear > 0)
        {
            pitchFromCar = carController.RPM/(8* carController.gear);
        }
        else if (carController.frontDriverW.motorTorque < 0)
        {
            pitchFromCar = carController.RPM / 15;
        }
        else if(carController.frontDriverW.motorTorque == 0 && carController.frontDriverW.brakeTorque == carController.decelerationForce)
        {
            pitchFromCar = Time.deltaTime;
        }
        if (pitchFromCar < minPitch)
        {
            sound.pitch = minPitch;
        }
        else
        {
            sound.pitch = pitchFromCar;
        }
    }
}
