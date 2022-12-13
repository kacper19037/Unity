using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarController : MonoBehaviour
{
    private float m_horizontalInput;
    private float m_verticalInput;
    private float m_steeringAngle;
    public Rigidbody rb;
    [Header("WheelsColliders")]
    public WheelCollider frontDriverW, frontPassengerW;
    public WheelCollider rearDriverW, rearPassengerW;
    [Header("WheelsTransform")]
    public Transform frontDriverT, frontPassengerT;
    public Transform rearDriverT, rearPassengerT;
    [Header("Gear")]
    public float KPH;
    public float RPM = 1.0f;
    public float multipler = 2;
    private float wheelsRPM;
    public bool reverse;
    public int gear = 0;
    [Header("Engine, Steer & Brake")]
    public float maxSteerAngle = 30;
    public float motorForce = 50;
    public float brakeTorque;
    public float decelerationForce;
    [Header("Lap & CheckPoints")]
    public int lapNumber;
    public int checkpointIndex;
    private Timer timer;
    [Header("Start time controller")]
    public GameObject TimerManager;


    private void Start()
    {
        TimerManager = GameObject.FindGameObjectWithTag("Time");
        timer = TimerManager.GetComponent<Timer>();
        lapNumber = 1;
        checkpointIndex = 0;
    }
    public void GetInput()
    {
        m_horizontalInput = Input.GetAxis("Horizontal");
        m_verticalInput = Input.GetAxis("Vertical");
    }
    private void Steer()
    {
        m_steeringAngle = maxSteerAngle * m_horizontalInput;
        frontDriverW.steerAngle = m_steeringAngle;
        frontPassengerW.steerAngle = m_steeringAngle;
    }
    private void Accelerate(float motor)
    {
        if (motor != 0f)
        {
            if(timer.startTime<=0.1)
            {
                frontDriverW.brakeTorque = 0;
                frontPassengerW.brakeTorque = 0;
            }
            else
            {
                HandBrake();
            }
            
            frontDriverW.motorTorque = motor;
            frontPassengerW.motorTorque = motor;
        }
        else
        {
            Deceleration();
        }
        KPH = rb.velocity.magnitude * 3.6f;
        do
        {
            RPM = (RPM + KPH)/5;
            if (gear == 0 && RPM > 1.0f && !reverse)
            {
                gear++;
            }
            else if (gear > 0 && gear < 6 && RPM > multipler*4)
            {
                multipler += 1;
                gear++;
            }
            else if (gear >0 &&  RPM < (multipler-1)*4)
            {
                multipler -= 1;
                gear--;
            }
            else if (gear == 1  && RPM < 1.0f)
            {
                    gear--;
            }
            else if (gear == 0 && frontDriverW.motorTorque<0)
            {
                reverse = true;
            }
            else if(reverse && frontDriverW.motorTorque > 0)
            {
                reverse = false;
            }
            
        }
        while (gear > 6);
    }
    private void Deceleration()
    {
        frontDriverW.brakeTorque = decelerationForce;
        frontPassengerW.brakeTorque = decelerationForce;
    }
    private void Brake()
    {
        frontDriverW.brakeTorque = brakeTorque;
        frontPassengerW.brakeTorque = brakeTorque;
    }
    private void HandBrake()
    {
        frontDriverW.brakeTorque = brakeTorque*10;
        frontPassengerW.brakeTorque = brakeTorque*10;
    }
    private void UpdateWheelPoses()
    {
        UpdateWheelPose(frontDriverW, frontDriverT);
        UpdateWheelPose(frontPassengerW, frontPassengerT);
        UpdateWheelPose(rearDriverW, rearDriverT);
        UpdateWheelPose(rearPassengerW, rearPassengerT);
    }
    private void UpdateWheelPose(WheelCollider _collider, Transform _transform)
    {
        
        Vector3 _pos = _transform.position;
        Quaternion _quat = _transform.rotation;

        _collider.GetWorldPose(out _pos, out _quat);

        _transform.position = _pos;
        _transform.rotation = _quat;
    }

    private void FixedUpdate()
    {
        float motor = motorForce * m_verticalInput;
        if(m_verticalInput<0 && !reverse)
        {
            Brake();
        }

        


        GetInput();
        Steer();
        Accelerate(motor);

        UpdateWheelPoses();
        if (Input.GetKey(KeyCode.Space))
        {
            HandBrake();
        }
        if (Input.GetKey(KeyCode.R))
        {
            transform.eulerAngles= new Vector3(transform.rotation.x, transform.rotation.y, 0);
        }

    }
    

}
