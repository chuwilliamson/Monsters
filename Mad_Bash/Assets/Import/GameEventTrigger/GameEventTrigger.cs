using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameEventTrigger : MonoBehaviour
{
    public List<GameEventTriggerEntry> Entries;
    private void OnEnable()
    {
        foreach (var e in Entries)
            e.Subscribe();
    }

    private void OnDisable()
    {
        foreach (var e in Entries)
            e.Unsubscribe();
    }
 
}