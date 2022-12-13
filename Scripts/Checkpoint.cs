using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Checkpoint : MonoBehaviour
{
    public int index;
    public TextMeshProUGUI wrongDirectionText;
    private void OnTriggerEnter(Collider collision)
    {
        if(collision.gameObject.GetComponent<CarController>())
        {
            CarController car = collision.gameObject.GetComponent<CarController>();
            if(car.checkpointIndex == index - 1)
            {
                car.checkpointIndex = index;
            }
            else if(car.checkpointIndex > index -1)
            {
                wrongDirectionText.enabled = true;
            }
        }   
    }
    void OnTriggerExit(Collider collision)
    {
           wrongDirectionText.enabled = false;
    }
}
