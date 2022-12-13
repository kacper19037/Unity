using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayMenu : MonoBehaviour
{
    public static bool isEasy;
    public static bool isMedium;
    public static bool isHard;
    private Timer timer;
    private AudioSource audio;
    public GameObject Car;
    public GameObject TimerManager;

    private void Start()
    {
        Car = GameObject.FindGameObjectWithTag("Car");
        audio = Car.GetComponent<AudioSource>();
        TimerManager = GameObject.FindGameObjectWithTag("Time");
        timer = TimerManager.GetComponent<Timer>();
    }
    public void PlayGame ()
    {
        if(isEasy || isMedium || isHard)
        {
            if(LevelSelect.isLevel1)
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            }
            else if(LevelSelect.isLevel2)
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 2);
            }
            
            timer.time = 0.0f;
        }
        
    }
    public void RestartGame()
    {
        audio.enabled = true;
        PauseMenu.GameIsResume = true;
        timer.time = 0.0f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex); 
        Time.timeScale = 1;
    }

    public void BackToMenu()
    {
        audio.enabled = true;
        PauseMenu.GameIsResume = true;

        if (LevelSelect.isLevel1)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
        }
        else if (LevelSelect.isLevel2)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 2);
        }
        Time.timeScale = 1;
        timer.time = 0.0f;


    }
    public void QuitGame()
    {
        Application.Quit();
    }
    public void Easy()
    {
        isEasy=true;
        isMedium = false;
        isHard = false;
    }
    public void Medium()
    {
        isEasy = false;
        isMedium = true;
        isHard = false;
    }
    public void Hard()
    {
        isEasy = false;
        isMedium = false;
        isHard = true;
    }
}
