using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LapManager : MonoBehaviour
{
    public List<Checkpoint> checkpoints;
    public int totalLaps;
    private Timer timer;
    private AudioSource audio;
    public GameObject TimerManager;
    public static float totalTime;
    public GameObject WinMenu;
    public GameObject Car;
    private void Start()
    {
        TimerManager = GameObject.FindGameObjectWithTag("Time");
        timer = TimerManager.GetComponent<Timer>();
        Car = GameObject.FindGameObjectWithTag("Car");
        audio = Car.GetComponent<AudioSource>();
        
    }
    private void OnTriggerEnter(Collider collision)
    {
        if(collision.gameObject.GetComponent<CarController>())
        {
            CarController car = collision.gameObject.GetComponent<CarController>();
            if(car.checkpointIndex == checkpoints.Count)
            {
                car.checkpointIndex = 0;
                car.lapNumber++;
                Debug.Log($"You are now on lap {car.lapNumber} out of {totalLaps}");
                if(car.lapNumber > totalLaps && timer.currentTime > 0)
                {
                    PauseMenu.GameIsResume = false;
                    timer.isFinish = true;
                    totalTime = timer.time - timer.currentTime;
                    Time.timeScale = 0;
                    audio.enabled = false;
                    WinMenu.SetActive(true);
                    Debug.Log("You Won");
                }
            }
        }
    }
}
