using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Speedometer : MonoBehaviour
{

    public Rigidbody target;
    public GameObject Car;
    public float maxSpeed = 0.0f;

    public float minSpeedArrowAngle;
    public float maxSpeedArrowAngle;
    private CarController carController;
    [Header("UI")]
    public Text speedLabel;
    public Text gearLabel;
    public RectTransform arrow;

    private float speed = 0.0f;
    public int gear;
    void Start()
    {
        Car = GameObject.FindGameObjectWithTag("Car");
        carController = Car.GetComponent<CarController>();
    }
    private void Update()
    {
        
        speed = target.velocity.magnitude * 7.3f;
        gear = carController.gear;

        if (gearLabel != null)
        {
            if(carController.reverse == false && gear>0)
            {
                gearLabel.text = gear+"";
            }
            else if(carController.reverse == false && gear ==0)
            {
                gearLabel.text = "N";
            }
            else if (carController.reverse == true)
            { 
                gearLabel.text = "R";
            }
        } 
        if (speedLabel != null)
            speedLabel.text = ((int)speed) + " km/h";
        if (arrow != null)
            arrow.localEulerAngles =
                new Vector3(0, 0, Mathf.Lerp(minSpeedArrowAngle, maxSpeedArrowAngle, speed / maxSpeed));
    }

}
