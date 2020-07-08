using System;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public Text TimerText;
    public float milliSeconds, seconds, minutes, intTimer;

    void Update()
    {
        intTimer += Time.deltaTime;
        minutes = (int)(intTimer/60f);
        seconds = (int)(intTimer % 60f);
        milliSeconds = (int)(intTimer * 100) % 100;
        TimerText.text = String.Format("{0:0}:{1:00}.{2:00}", minutes, seconds, milliSeconds);
    }
}
