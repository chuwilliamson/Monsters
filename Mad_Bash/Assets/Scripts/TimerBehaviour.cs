using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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
        /*===== Tester Code =====*/
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

        /*===== Tester Code =====*/
        if (Input.GetKeyDown(KeyCode.T))
        {
            Debug.Log("Seconds: " + _timestamp.Seconds.ToString());
            Debug.Log("Minutes: " + _timestamp.Minutes.ToString());
            Debug.Log("Hours: " + _timestamp.Hours.ToString());
        }

        if (Timing == true)
        {
            timePassed += Time.deltaTime * timerScale;

            /*===== This block of code is to be used for raw float values =====*/

            _timestamp.Seconds = timePassed;
            _timestamp.Minutes = timePassed / 60;
            _timestamp.Hours = timePassed / 3600;

            /*===== This block of code is to be used for a "00:00:00" =====*/

            //_timestamp.Hours = Mathf.Floor((theTime % 216000) / 3600);
            //_timestamp.Minutes = Mathf.Floor((theTime % 3600) / 60);
            //_timestamp.Seconds = (theTime % 60);
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
}
