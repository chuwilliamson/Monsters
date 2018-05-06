using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Events;
using Object = UnityEngine.Object;

[Serializable]
public class GameEventArgsWaitListener : GameEventArgsListener
{ 
    [ReadOnly] public float Timer;
    [Range(0, 3)] public float WaitTime = 3; 

    public override void OnEventRaised(Object[] args)
    {
        StartCoroutine(routine: WaitAndInvoke(args));
    }
 
    private void OnEnable()
    {
        Timer = WaitTime;
        Subscribe();
    }

    private void OnDisable()
    {
        Unsubscribe();
    }

    public IEnumerator WaitAndInvoke(Object[] args)
    {
        var current = WaitTime;
        while (current > 0)
        {
            Timer = Mathf.Clamp01(value: Timer - Time.deltaTime);
            yield return current -= Time.deltaTime;
        }
        yield return new WaitForSeconds(WaitTime);
        Response.Invoke(args);
    }
}