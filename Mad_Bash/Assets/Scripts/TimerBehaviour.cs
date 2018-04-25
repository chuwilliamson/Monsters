using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Reflection;

public class TimeElapsed
{
    public TimeElapsed() { }

    public float Seconds { get; set; }
    public float Minutes { get; set; }
    public float Hours { get; set; }

    public void ClearTime()
    {
        Hours = 0;
        Minutes = 0;
        Seconds = 0;
    }
}

public class TimerBehaviour : MonoBehaviour
{
    public bool Timing;
    public float timerScale = 1;
    public float timePassed = 0;

    [SerializeField]
    public TimeElapsed _timestamp;

    private void Start()
    {
        _timestamp = new TimeElapsed();
    }

    private void Update()
    {
        ClearConsole();
        Debug.Log("Seconds: " + _timestamp.Seconds.ToString());
        Debug.Log("Minutes: " + _timestamp.Minutes.ToString());
        Debug.Log("Hours: " + _timestamp.Hours.ToString());
        
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (Timing == true)
            {
                PauseTimer();
            }
            else
            {
                StartTimer();
            }
        }

        if (Input.GetKeyDown(KeyCode.C))
        {
            ResetTimer();
        }

        if (Timing == true)
        {
            timePassed += Time.deltaTime * timerScale;
            _timestamp.Seconds = timePassed;
            _timestamp.Minutes = timePassed / 60;
            _timestamp.Hours = timePassed / 3600;
        }
    }

    public void StartTimer()
    {
        Timing = true;
    }

    public void PauseTimer()
    {
        Timing = false;
    }

    public void ResetTimer()
    {
        PauseTimer();
        _timestamp.ClearTime();
        timePassed = 0f;
    }

    public TimeElapsed GetTime()
    {
        return _timestamp;
    }

    public static void ClearConsole()
    {
        var assembly = Assembly.GetAssembly(typeof(UnityEditor.SceneView));
        var type = assembly.GetType("UnityEditor.LogEntries");
        var method = type.GetMethod("Clear");
        method.Invoke(new object(), null);
    }
}
