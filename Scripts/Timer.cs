using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    [Header("Component")]
    public TextMeshProUGUI timerText;
    public TextMeshProUGUI startTimerText;
    public GameObject LostMenu;
    private AudioSource audio;
    public GameObject Car;
    [Header("Timer Settings")]
    public float currentTime;
    public bool countDown;
    [Header("Limit Settings")]
    public bool hasLimit;
    public float timerLimit;
    [Header("Format Settings")]
    public bool hasFormat;
    public TimerFormats format;
    private Dictionary<TimerFormats, string> timeFormats = new Dictionary<TimerFormats, string>();
    [Header("Start Time Settings")]
    public float startTime;
    public float time;
    private float endStartTime;
    public bool isStartTime = true;
    public bool isFinish = false;
    void Start()
    {
        Car = GameObject.FindGameObjectWithTag("Car");
        audio = Car.GetComponent<AudioSource>();
        if (LevelSelect.isLevel1)
        {
            if (PlayMenu.isEasy)
            {
                currentTime = 100.0f;
            }
            else if (PlayMenu.isMedium)
            {
                currentTime = 80.0f;
            }
            else
            {
                currentTime = 60.0f;
            }
        }
        else if (LevelSelect.isLevel2)
        {
            if (PlayMenu.isEasy)
            {
                currentTime = 200.0f;
            }
            else if (PlayMenu.isMedium)
            {
                currentTime = 180.0f;
            }
            else
            {
                currentTime = 150.0f;
            }
        }
        
        time = currentTime;
        timeFormats.Add(TimerFormats.Whole, "0");
        timeFormats.Add(TimerFormats.TenthDecimal, "0.0");
        timeFormats.Add(TimerFormats.HundrethsDecimal, "0.00");
        
        endStartTime = currentTime - 1.5f;
    }

    
    void Update()
    {
        if(isStartTime)
        {
            startTime = countDown ? startTime -= Time.deltaTime : startTime += Time.deltaTime;
            if(startTime > 0.5)
            {
                startTimerText.text = startTime.ToString("0");
            }
            else if (startTime>0 && startTime<0.5)
            {
                startTimerText.text = "GO";
                if(startTime<0.4)
                {
                    isStartTime = false;
                }
                
            }              
        }
        else
        {
            if (!isFinish)
            {
                currentTime = countDown ? currentTime -= Time.deltaTime : currentTime += Time.deltaTime;
            }
            
            startTime = 0;
            if (currentTime< endStartTime)
            {
                startTimerText.enabled = false;
            }
            
            
            if (hasLimit && ((countDown && currentTime <= timerLimit) || (!countDown && currentTime >= timerLimit)))
            {
                currentTime = timerLimit;
                SetTimerText();
                timerText.color = Color.red;
                enabled = false;
                Time.timeScale = 0;
                audio.enabled = false;
                LostMenu.SetActive(true);
            }
            SetTimerText();
        }
        
    }

    private void SetTimerText()
    {
        timerText.text = hasFormat ? currentTime.ToString(timeFormats[format]) : currentTime.ToString();
    }
    public enum TimerFormats
    {
        Whole,
        TenthDecimal,
        HundrethsDecimal
    }
}
