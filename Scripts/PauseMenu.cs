using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    public static bool GameIsPaused = false;
    public static bool GameIsResume = true;
    public GameObject pauseMenu;
    private AudioSource audio;
    public GameObject Car;

    private void Start()
    {
        Car = GameObject.FindGameObjectWithTag("Car");
        audio = Car.GetComponent<AudioSource>();
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (GameIsPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }
    public void Resume()
    {
        pauseMenu.SetActive(false);
        if (GameIsResume)
        {
            Time.timeScale = 1f;
            GameIsPaused = false;
            audio.enabled = true;
        }
        

    }
    void Pause()
    {
        pauseMenu.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
        audio.enabled = false;
    }
}
