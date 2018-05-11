using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameLoseBehaviour : MonoBehaviour
{
    [SerializeField]
    private GameEventArgs GameLose;

    public void GameOver()
    {
        GameLose.Raise();
    }
}