using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;



public class TimeSave : MonoBehaviour
{
    public TextMeshProUGUI yourTime;
    // Start is called before the first frame update
    void Start()
    {
        float time = LapManager.totalTime;
        yourTime.text = LapManager.totalTime.ToString("Your time is 0.0");
    }
}
