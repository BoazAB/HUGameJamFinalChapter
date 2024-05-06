using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Stopwatch : MonoBehaviour
{
    public static float time = 0f;
    private bool isStopwatchRunning = true;
    [SerializeField] private TextMeshProUGUI stopwatchText;
    void Start()
    {
        time = 0f;
    }
    void Update()
    {
        if (isStopwatchRunning)
        {
            time += Time.deltaTime;
            UpdateStopwatchUI();
        }
    }

    void UpdateStopwatchUI()
    {
        stopwatchText.text = "Time: " + FormatTime(time);
    }

    string FormatTime(float timeInSeconds)
    {
        int minutes = Mathf.FloorToInt(timeInSeconds / 60);
        int seconds = Mathf.FloorToInt(timeInSeconds % 60);

        return string.Format("{0:00}:{1:00}", minutes, seconds);
    }

    public void WinGame()
    {
        isStopwatchRunning = false;
        Stopwatch.time = time;
        SceneManager.LoadScene("YouWin");
    }
}
