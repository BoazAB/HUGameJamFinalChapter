using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DisplayTime : MonoBehaviour
{
    public TextMeshProUGUI winningTimeText;

    void Start()
    {
        float winningTime = Stopwatch.time; // Get the elapsed time from the static variable
        winningTimeText.text = "Winning Time: " + FormatTime(winningTime);
    }

    string FormatTime(float timeInSeconds)
    {
        int minutes = Mathf.FloorToInt(timeInSeconds / 60);
        int seconds = Mathf.FloorToInt(timeInSeconds % 60);

        return string.Format("{0:00}:{1:00}", minutes, seconds);
    }
}
